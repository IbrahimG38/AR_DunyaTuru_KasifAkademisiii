// UnityEngine k�t�phanesini projeye dahil eder, Unity'nin temel s�n�f ve i�levlerine eri�im sa�lar.
using UnityEngine;

// WelcomeManager ad�nda bir s�n�f tan�mlan�yor. MonoBehaviour'dan t�retilmi�,
// yani bir Unity bile�eni olarak sahnedeki GameObject'lere eklenebilir.
public class WelcomeManager : MonoBehaviour
{
    // Unity Edit�r� �zerinden atanabilen, ho� geldiniz panelini temsil eden GameObject referans�.
    public GameObject welcomePanel;

    // Bu metod, uygulaman�n ba�lang�c�nda kullan�c� taraf�ndan tetiklenebilir.
    // �rne�in, bir "Ba�la" butonuna t�kland���nda �a�r�labilir.
    public void StartApp()
    {
        // Ho� geldiniz panelini devre d��� b�rak�r, yani paneli gizler.
        welcomePanel.SetActive(false);
    }
}
