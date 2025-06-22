// Unity'nin temel bileþenlerini kullanmak için gerekli kütüphane
using UnityEngine;

// TextMeshPro (TMP) UI bileþenlerini kullanmak için gerekli kütüphane
using TMPro;

// InfoPanelManager adýnda bir sýnýf tanýmlanýyor. MonoBehaviour'dan türetilmiþ.
// Bu sýnýf, bilgi panelinin kontrolünü saðlar (aç/kapa ve metin gösterme).
public class InfoPanelManager : MonoBehaviour
{
    // Bilgi panelini temsil eden GameObject (örneðin bir UI Panel).
    public GameObject infoPanel;

    // Bilgi panelinde gösterilecek olan metni temsil eder. TextMeshPro kullandýðý için TMP tipi.
    public TextMeshProUGUI infoText;

    // Paneli açmak ve metni göstermek için kullanýlan fonksiyon.
    public void ShowInfo(string content)
    {
        // infoText bileþenine, parametre olarak gelen yazýyý aktarýr.
        infoText.text = content;

        // Paneli aktif hale getirir (ekranda görünür yapar).
        infoPanel.SetActive(true);
    }

    // Paneli kapatmak için kullanýlan fonksiyon.
    public void HideInfo()
    {
        // Paneli devre dýþý býrakýr (ekranda gizler).
        infoPanel.SetActive(false);
    }
}
