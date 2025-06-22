// Unity'nin temel bileþenlerine eriþmek için gerekli kütüphane
using UnityEngine;

// UI bileþenlerine (Button, Text, Image vs.) eriþmek için gerekli kütüphane
using UnityEngine.UI;

// CloseButtonHandler adýnda bir sýnýf tanýmlanýyor. MonoBehaviour'dan türetilmiþ.
// Bu script genellikle bir butonun týklanmasýyla bir paneli gizlemek için kullanýlýr.
public class CloseButtonHandler : MonoBehaviour
{
    // Kapatýlacak olan paneli temsil eden GameObject. Unity editörü üzerinden atanýr.
    public GameObject infoPanel;

    // Bu scriptin çalýþtýðý objeye atanmýþ olan UI butonu
    public Button closeButton;

    // Unity sahne baþladýðýnda (script etkinleþtiðinde) çalýþýr
    void Start()
    {
        // closeButton nesnesine týklandýðýnda ClosePanel fonksiyonunu çaðýrmasýný söyleriz
        closeButton.onClick.AddListener(ClosePanel);
    }

    // Paneli kapatmak (gizlemek) için kullanýlan fonksiyon
    public void ClosePanel()
    {
        // infoPanel'i devre dýþý býrakýr (ekrandan gizler)
        infoPanel.SetActive(false);
        FindObjectOfType<QuestionManager>().OpenPanel();

    }
}
