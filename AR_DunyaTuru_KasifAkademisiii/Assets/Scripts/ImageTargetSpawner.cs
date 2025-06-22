// Unity'nin temel s�n�f ve bile�enlerini kullanmam�za olanak tan�r.
using UnityEngine;

// AR Foundation i�in gerekli s�n�flar� i�eren k�t�phane. AR �zelliklerini kontrol etmemizi sa�lar.
using UnityEngine.XR.ARFoundation;

// AR cihazlar�nda g�r�nt� tan�ma gibi �zellikleri sa�layan alt sistemleri i�erir.
using UnityEngine.XR.ARSubsystems;

// ImageTargetSpawner ad�nda bir s�n�f tan�mlan�yor. MonoBehaviour�dan t�retilmi�.
public class ImageTargetSpawner : MonoBehaviour
{
    // Sahneye yerle�tirilecek olan 3D modelleri tutan dizi. Bunlar Edit�r'den atan�r.
    public GameObject[] models;

    // ARTrackedImageManager, tan�nan g�r�nt�leri takip etmeye yarar. AR Image Tracking sistemi buradan kontrol edilir.
    public ARTrackedImageManager trackedImageManager;

    // Script etkinle�tirildi�inde (�rn. GameObject aktif hale geldi�inde) �al���r.
    void OnEnable()
    {
        // trackedImagesChanged event'ine, OnTrackedImagesChanged metodunu dinleyici (listener) olarak ekleriz.
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    // Script devre d��� b�rak�ld���nda �al���r. Bellek y�netimi ve performans i�in event kald�r�l�r.
    void OnDisable()
    {
        // trackedImagesChanged event'inden dinleyiciyi kald�r�r�z.
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    // Yeni bir g�rsel tan�nd���nda, g�ncellendi�inde veya kayboldu�unda �a�r�l�r.
    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // Yeni tan�nan her bir g�r�nt� i�in bir model olu�tururuz.
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            SpawnModel(trackedImage);
        }

        // Zaten tan�nm�� ama yeri veya durumu de�i�mi� g�r�nt�ler i�in modelin pozisyonunu g�ncelleriz.
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateModelPosition(trackedImage);
        }

        // Art�k tan�nmayan (kameradan ��kan vs.) g�r�nt�ler i�in modeli sahneden kald�r�r�z.
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            RemoveModel(trackedImage);
        }
    }

    // G�r�nt� tan�nd���nda sahneye rastgele bir modeli yerle�tiren metod.
    void SpawnModel(ARTrackedImage trackedImage)
    {
        // Modeller dizisinden rastgele birini se�ip, g�r�nt�n�n konum ve rotasyonuna instantiate (olu�turma) i�lemi yap�yoruz.
        GameObject model = Instantiate(models[Random.Range(0, models.Length)], trackedImage.transform.position, trackedImage.transform.rotation);

        // Olu�turulan modeli g�r�nt�n�n alt objesi (child) olarak ekliyoruz. B�ylece model, g�r�nt�yle birlikte hareket eder.
        model.transform.SetParent(trackedImage.transform);
    }

    // G�r�nt� takip edildi�i s�rece modelin pozisyonunu g�ncelleyen metod.
    void UpdateModelPosition(ARTrackedImage trackedImage)
    {
        // Image Target alt�ndaki ilk objeyi (modeli) al�yoruz.
        Transform model = trackedImage.transform.GetChild(0);

        // E�er model varsa, konum ve y�n�n� g�ncelliyoruz.
        if (model != null)
        {
            model.position = trackedImage.transform.position;
            model.rotation = trackedImage.transform.rotation;
        }
    }

    // G�r�nt� art�k izlenmedi�inde (kameradan ��karsa vb.) modeli sahneden kald�ran metod.
    void RemoveModel(ARTrackedImage trackedImage)
    {
        // E�er g�r�nt�n�n alt�nda en az bir �ocuk obje varsa (yani model sahnedeyse),
        if (trackedImage.transform.childCount > 0)
        {
            // �lk �ocu�u (modeli) sahneden kald�r�yoruz.
            Destroy(trackedImage.transform.GetChild(0).gameObject);
        }
    }
}
