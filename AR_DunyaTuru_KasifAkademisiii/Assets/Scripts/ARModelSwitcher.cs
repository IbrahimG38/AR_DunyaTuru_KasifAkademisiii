// Unity'nin temel i�levleri i�in gerekli k�t�phane.
using UnityEngine;

// AR Foundation'daki AR �zelliklerini (takip, tan�ma vb.) kullanmak i�in gerekli k�t�phane.
using UnityEngine.XR.ARFoundation;

// AR alt sistemlerine (g�rsel tan�ma gibi) eri�mek i�in gerekli k�t�phane.
using UnityEngine.XR.ARSubsystems;

// ARModelSwitcher ad�nda bir s�n�f tan�mlan�yor. MonoBehaviour�dan t�retilmi�.
public class ARModelSwitcher : MonoBehaviour
{
    // Eiffel Kulesi modelini temsil eden GameObject. Edit�r �zerinden atan�r.
    public GameObject Eiffel;

    // Pisa Kulesi modelini temsil eden GameObject.
    public GameObject Pisa;

    // ARTrackedImageManager s�n�f�ndan bir referans tan�mlan�yor.
    private ARTrackedImageManager trackedImageManager;

    // Uygulama ba�lad���nda �al��an metod.
    void Start()
    {
        // Sahnedeki ARTrackedImageManager bile�enini bulup referansa at�yoruz.
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        // G�r�nt� de�i�ikli�i oldu�unda (yeni g�r�nt� tan�nd���nda) �al��acak olan metoda abone oluyoruz.
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    // Bir g�r�nt� tan�nd���nda veya de�i�ti�inde �a�r�l�r.
    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        // Yeni tan�nan her bir g�r�nt� i�in i�lem yap�l�r.
        foreach (var addedImage in args.added)
        {
            // E�er tan�nan g�rselin ismi "Eiffel" ise:
            if (addedImage.referenceImage.name == "Eiffel") // Eiffel Tower g�rseli
            {
                Eiffel.SetActive(true);  // Eiffel modelini g�ster.
                Pisa.SetActive(false);   // Pisa modelini gizle.
            }
            // E�er tan�nan g�rselin ismi "Pisa" ise:
            else if (addedImage.referenceImage.name == "Pisa") // Pisa Kulesi G�rseli
            {
                Eiffel.SetActive(false); // Eiffel modelini gizle.
                Pisa.SetActive(true);    // Pisa modelini g�ster.
            }
        }
    }
}
