using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public GameObject questionPanel;
    public Button showQuestionButton;
    public Text questionText;
    public Button yesButton;
    public Button noButton;
    public Text feedbackText;
    public GameObject rewardImage;

    private void Start()
    {
        // Ba�ta her �ey kapal�
        questionPanel.SetActive(false);
        questionText.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        feedbackText.gameObject.SetActive(false);
        rewardImage.SetActive(false);

        showQuestionButton.onClick.AddListener(ShowQuestion);
        yesButton.onClick.AddListener(() => CheckAnswer(true));
        noButton.onClick.AddListener(() => CheckAnswer(false));
    }

    public void OpenPanel()
    {
        questionPanel.SetActive(true);
        showQuestionButton.gameObject.SetActive(true);
    }

    void ShowQuestion()
    {
        showQuestionButton.gameObject.SetActive(false);
        questionText.gameObject.SetActive(true);
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
        questionText.text = "Eiffel Kulesi, ismini Frans�z �n�aat M�hendisi Gustave Eiffel'den mi alm��t�r?";
    }

    void CheckAnswer(bool userAnswer)
    {
        questionText.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        feedbackText.gameObject.SetActive(true);

        if (userAnswer == true) // Do�ru cevap "Evet"
        {
            feedbackText.text = "Tebrikler!";
            rewardImage.SetActive(true);
        }
        else
        {
            feedbackText.text = "Maalesef cevab�n yanl��, daha dikkatli olmal�s�n.";
        }
    }
}
