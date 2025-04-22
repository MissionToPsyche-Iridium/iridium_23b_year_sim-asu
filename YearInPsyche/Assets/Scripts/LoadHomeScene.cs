using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadHomeScene : MonoBehaviour
{
    public Button homeButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        homeButton.onClick.AddListener(() => OnButtonClicked(1));
    }

    void OnButtonClicked(int buttonNumber)
    {
        switch (buttonNumber)
        {
            case 1:
                if (SceneManager.GetActiveScene().buildIndex == 16)
                    QuizManager.ReturnedFromEndOfQuiz = true;
                SceneManager.LoadScene("SolarSystemPrototype");
                break;
            default:
                break;
        }
    }
}
