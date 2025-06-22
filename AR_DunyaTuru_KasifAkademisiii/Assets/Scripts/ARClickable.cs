// UnityEngine kütüphanesini projeye dahil eder, temel Unity iþlevlerini kullanabilmemizi saðlar.
using UnityEngine;

// Unity'nin EventSystems kütüphanesini dahil eder. Bu, kullanýcý etkileþimlerini (týklama, sürükleme vs.) yönetmek için kullanýlýr.
using UnityEngine.EventSystems;

// ARClickable adýnda bir sýnýf tanýmlanýyor. MonoBehaviour'dan türetilmiþ ve IPointerClickHandler arayüzünü implemente ediyor.
// Bu sayede týklama olaylarýna tepki verebilecek.
public class ARClickable : MonoBehaviour, IPointerClickHandler
{
    // Bilgi panelinde gösterilecek içeriði tutan bir metin deðiþkeni.
    public string infoContent;

    // Kullanýcý bu nesneye týkladýðýnda otomatik olarak çaðrýlan metod.
    public void OnPointerClick(PointerEventData eventData)
    {
        // Sahnedeki InfoPanelManager türündeki ilk objeyi bulur ve ShowInfo fonksiyonunu çaðýrarak
        // infoContent deðiþkenindeki bilgiyi gösterir.
        FindObjectOfType<InfoPanelManager>().ShowInfo(infoContent);
    }
}

