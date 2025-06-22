// Unity'nin temel iþlevleri için gerekli kütüphane.
using UnityEngine;

// AR Foundation'daki AR özelliklerini (takip, tanýma vb.) kullanmak için gerekli kütüphane.
using UnityEngine.XR.ARFoundation;

// AR alt sistemlerine (görsel tanýma gibi) eriþmek için gerekli kütüphane.
using UnityEngine.XR.ARSubsystems;

// ARModelSwitcher adýnda bir sýnýf tanýmlanýyor. MonoBehaviour’dan türetilmiþ.
public class ARModelSwitcher : MonoBehaviour
{
    // Eiffel Kulesi modelini temsil eden GameObject. Editör üzerinden atanýr.
    public GameObject Eiffel;

    // Pisa Kulesi modelini temsil eden GameObject.
    public GameObject Pisa;

    // ARTrackedImageManager sýnýfýndan bir referans tanýmlanýyor.
    private ARTrackedImageManager trackedImageManager;

    // Uygulama baþladýðýnda çalýþan metod.
    void Start()
    {
        // Sahnedeki ARTrackedImageManager bileþenini bulup referansa atýyoruz.
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        // Görüntü deðiþikliði olduðunda (yeni görüntü tanýndýðýnda) çalýþacak olan metoda abone oluyoruz.
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    // Bir görüntü tanýndýðýnda veya deðiþtiðinde çaðrýlýr.
    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        // Yeni tanýnan her bir görüntü için iþlem yapýlýr.
        foreach (var addedImage in args.added)
        {
            // Eðer tanýnan görselin ismi "Eiffel" ise:
            if (addedImage.referenceImage.name == "Eiffel") // Eiffel Tower görseli
            {
                Eiffel.SetActive(true);  // Eiffel modelini göster.
                Pisa.SetActive(false);   // Pisa modelini gizle.
            }
            // Eðer tanýnan görselin ismi "Pisa" ise:
            else if (addedImage.referenceImage.name == "Pisa") // Pisa Kulesi Görseli
            {
                Eiffel.SetActive(false); // Eiffel modelini gizle.
                Pisa.SetActive(true);    // Pisa modelini göster.
            }
        }
    }
}
