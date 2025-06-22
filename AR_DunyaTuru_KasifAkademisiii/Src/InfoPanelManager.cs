// Unity'nin temel bile�enlerini kullanmak i�in gerekli k�t�phane
using UnityEngine;

// TextMeshPro (TMP) UI bile�enlerini kullanmak i�in gerekli k�t�phane
using TMPro;

// InfoPanelManager ad�nda bir s�n�f tan�mlan�yor. MonoBehaviour'dan t�retilmi�.
// Bu s�n�f, bilgi panelinin kontrol�n� sa�lar (a�/kapa ve metin g�sterme).
public class InfoPanelManager : MonoBehaviour
{
    // Bilgi panelini temsil eden GameObject (�rne�in bir UI Panel).
    public GameObject infoPanel;

    // Bilgi panelinde g�sterilecek olan metni temsil eder. TextMeshPro kulland��� i�in TMP tipi.
    public TextMeshProUGUI infoText;

    // Paneli a�mak ve metni g�stermek i�in kullan�lan fonksiyon.
    public void ShowInfo(string content)
    {
        // infoText bile�enine, parametre olarak gelen yaz�y� aktar�r.
        infoText.text = content;

        // Paneli aktif hale getirir (ekranda g�r�n�r yapar).
        infoPanel.SetActive(true);
    }

    // Paneli kapatmak i�in kullan�lan fonksiyon.
    public void HideInfo()
    {
        // Paneli devre d��� b�rak�r (ekranda gizler).
        infoPanel.SetActive(false);
    }
}
