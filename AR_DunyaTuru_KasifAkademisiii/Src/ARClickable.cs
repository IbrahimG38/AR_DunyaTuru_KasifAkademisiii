// UnityEngine k�t�phanesini projeye dahil eder, temel Unity i�levlerini kullanabilmemizi sa�lar.
using UnityEngine;

// Unity'nin EventSystems k�t�phanesini dahil eder. Bu, kullan�c� etkile�imlerini (t�klama, s�r�kleme vs.) y�netmek i�in kullan�l�r.
using UnityEngine.EventSystems;

// ARClickable ad�nda bir s�n�f tan�mlan�yor. MonoBehaviour'dan t�retilmi� ve IPointerClickHandler aray�z�n� implemente ediyor.
// Bu sayede t�klama olaylar�na tepki verebilecek.
public class ARClickable : MonoBehaviour, IPointerClickHandler
{
    // Bilgi panelinde g�sterilecek i�eri�i tutan bir metin de�i�keni.
    public string infoContent;

    // Kullan�c� bu nesneye t�klad���nda otomatik olarak �a�r�lan metod.
    public void OnPointerClick(PointerEventData eventData)
    {
        // Sahnedeki InfoPanelManager t�r�ndeki ilk objeyi bulur ve ShowInfo fonksiyonunu �a��rarak
        // infoContent de�i�kenindeki bilgiyi g�sterir.
        FindObjectOfType<InfoPanelManager>().ShowInfo(infoContent);
    }
}

