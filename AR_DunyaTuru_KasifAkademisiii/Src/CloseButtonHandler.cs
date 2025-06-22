// Unity'nin temel bile�enlerine eri�mek i�in gerekli k�t�phane
using UnityEngine;

// UI bile�enlerine (Button, Text, Image vs.) eri�mek i�in gerekli k�t�phane
using UnityEngine.UI;

// CloseButtonHandler ad�nda bir s�n�f tan�mlan�yor. MonoBehaviour'dan t�retilmi�.
// Bu script genellikle bir butonun t�klanmas�yla bir paneli gizlemek i�in kullan�l�r.
public class CloseButtonHandler : MonoBehaviour
{
    // Kapat�lacak olan paneli temsil eden GameObject. Unity edit�r� �zerinden atan�r.
    public GameObject infoPanel;

    // Bu scriptin �al��t��� objeye atanm�� olan UI butonu
    public Button closeButton;

    // Unity sahne ba�lad���nda (script etkinle�ti�inde) �al���r
    void Start()
    {
        // closeButton nesnesine t�kland���nda ClosePanel fonksiyonunu �a��rmas�n� s�yleriz
        closeButton.onClick.AddListener(ClosePanel);
    }

    // Paneli kapatmak (gizlemek) i�in kullan�lan fonksiyon
    public void ClosePanel()
    {
        // infoPanel'i devre d��� b�rak�r (ekrandan gizler)
        infoPanel.SetActive(false);
        FindObjectOfType<QuestionManager>().OpenPanel();

    }
}
