// UnityEngine kütüphanesini projeye dahil eder, Unity'nin temel sýnýf ve iþlevlerine eriþim saðlar.
using UnityEngine;

// WelcomeManager adýnda bir sýnýf tanýmlanýyor. MonoBehaviour'dan türetilmiþ,
// yani bir Unity bileþeni olarak sahnedeki GameObject'lere eklenebilir.
public class WelcomeManager : MonoBehaviour
{
    // Unity Editörü üzerinden atanabilen, hoþ geldiniz panelini temsil eden GameObject referansý.
    public GameObject welcomePanel;

    // Bu metod, uygulamanýn baþlangýcýnda kullanýcý tarafýndan tetiklenebilir.
    // Örneðin, bir "Baþla" butonuna týklandýðýnda çaðrýlabilir.
    public void StartApp()
    {
        // Hoþ geldiniz panelini devre dýþý býrakýr, yani paneli gizler.
        welcomePanel.SetActive(false);
    }
}
