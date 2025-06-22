// Unity'nin temel sýnýf ve bileþenlerini kullanmamýza olanak tanýr.
using UnityEngine;

// AR Foundation için gerekli sýnýflarý içeren kütüphane. AR özelliklerini kontrol etmemizi saðlar.
using UnityEngine.XR.ARFoundation;

// AR cihazlarýnda görüntü tanýma gibi özellikleri saðlayan alt sistemleri içerir.
using UnityEngine.XR.ARSubsystems;

// ImageTargetSpawner adýnda bir sýnýf tanýmlanýyor. MonoBehaviour’dan türetilmiþ.
public class ImageTargetSpawner : MonoBehaviour
{
    // Sahneye yerleþtirilecek olan 3D modelleri tutan dizi. Bunlar Editör'den atanýr.
    public GameObject[] models;

    // ARTrackedImageManager, tanýnan görüntüleri takip etmeye yarar. AR Image Tracking sistemi buradan kontrol edilir.
    public ARTrackedImageManager trackedImageManager;

    // Script etkinleþtirildiðinde (örn. GameObject aktif hale geldiðinde) çalýþýr.
    void OnEnable()
    {
        // trackedImagesChanged event'ine, OnTrackedImagesChanged metodunu dinleyici (listener) olarak ekleriz.
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    // Script devre dýþý býrakýldýðýnda çalýþýr. Bellek yönetimi ve performans için event kaldýrýlýr.
    void OnDisable()
    {
        // trackedImagesChanged event'inden dinleyiciyi kaldýrýrýz.
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    // Yeni bir görsel tanýndýðýnda, güncellendiðinde veya kaybolduðunda çaðrýlýr.
    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // Yeni tanýnan her bir görüntü için bir model oluþtururuz.
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            SpawnModel(trackedImage);
        }

        // Zaten tanýnmýþ ama yeri veya durumu deðiþmiþ görüntüler için modelin pozisyonunu güncelleriz.
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateModelPosition(trackedImage);
        }

        // Artýk tanýnmayan (kameradan çýkan vs.) görüntüler için modeli sahneden kaldýrýrýz.
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            RemoveModel(trackedImage);
        }
    }

    // Görüntü tanýndýðýnda sahneye rastgele bir modeli yerleþtiren metod.
    void SpawnModel(ARTrackedImage trackedImage)
    {
        // Modeller dizisinden rastgele birini seçip, görüntünün konum ve rotasyonuna instantiate (oluþturma) iþlemi yapýyoruz.
        GameObject model = Instantiate(models[Random.Range(0, models.Length)], trackedImage.transform.position, trackedImage.transform.rotation);

        // Oluþturulan modeli görüntünün alt objesi (child) olarak ekliyoruz. Böylece model, görüntüyle birlikte hareket eder.
        model.transform.SetParent(trackedImage.transform);
    }

    // Görüntü takip edildiði sürece modelin pozisyonunu güncelleyen metod.
    void UpdateModelPosition(ARTrackedImage trackedImage)
    {
        // Image Target altýndaki ilk objeyi (modeli) alýyoruz.
        Transform model = trackedImage.transform.GetChild(0);

        // Eðer model varsa, konum ve yönünü güncelliyoruz.
        if (model != null)
        {
            model.position = trackedImage.transform.position;
            model.rotation = trackedImage.transform.rotation;
        }
    }

    // Görüntü artýk izlenmediðinde (kameradan çýkarsa vb.) modeli sahneden kaldýran metod.
    void RemoveModel(ARTrackedImage trackedImage)
    {
        // Eðer görüntünün altýnda en az bir çocuk obje varsa (yani model sahnedeyse),
        if (trackedImage.transform.childCount > 0)
        {
            // Ýlk çocuðu (modeli) sahneden kaldýrýyoruz.
            Destroy(trackedImage.transform.GetChild(0).gameObject);
        }
    }
}
