using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    // Main menu UI
    public Button simulation;
    public Button quiz;
    public Button comparison;
    public Button credits;
    public Button back;
    public GameObject menuCanvas;

    // Comparison UI
    public Button fighterJet;
    public Button roastChicken;
    public Button potato;
    public GameObject interactiveCanvas;

    // Quiz score UI
    public GameObject quizScoreCanvas;
    public TextMeshProUGUI quizScores;
    public Button restartQuiz;
    public Button returnHome;
    public Button returnHomeScoreCanvas;

    // Simulation UI
    public GameObject simulationCanvas;

    private bool isPysche = true;
    private GameObject psyche;

    void Start()
    {
        simulation.onClick.AddListener(() => OnButtonClicked(1));
        quiz.onClick.AddListener(() => OnButtonClicked(2));
        credits.onClick.AddListener(() => OnButtonClicked(3));
        back.onClick.AddListener(() => OnButtonClicked(4));
        comparison.onClick.AddListener(() => OnButtonClicked(5));
        fighterJet.onClick.AddListener(() => OnButtonClicked(6));
        roastChicken.onClick.AddListener(() => OnButtonClicked(7));
        potato.onClick.AddListener(() => OnButtonClicked(8));
        restartQuiz.onClick.AddListener(() => OnButtonClicked(2));
        returnHome.onClick.AddListener(() => OnButtonClicked(4));
        returnHomeScoreCanvas.onClick.AddListener(() => OnButtonClicked(4));

        psyche = GameObject.Find("Psyche");
        if (psyche != null) psyche.SetActive(true);

        if (QuizManager.ReturnedFromEndOfQuiz)
        {
            menuCanvas.SetActive(false);
            quizScoreCanvas.SetActive(true);

            int score = QuizManager.Instance != null ? QuizManager.Instance.GetScore() : 0;
            quizScores.text = $"{score:D2}";

            QuizManager.ReturnedFromEndOfQuiz = false;
            if (psyche != null) psyche.SetActive(false);
                isPysche = false;
        }
    }

    void OnButtonClicked(int buttonNumber)
    {
        switch (buttonNumber)
        {
            case 1: // Simulation
                menuCanvas.SetActive(false);
                simulationCanvas.SetActive(true);

                Button homeButton = simulationCanvas.GetComponentInChildren<Button>();
                if (homeButton != null)
                    homeButton.onClick.AddListener(() => OnButtonClicked(9));

                if (psyche != null)
                {
                    var orbitalScript = psyche.GetComponent<OrbitalMotion>();
                    if (orbitalScript != null) orbitalScript.enabled = true;
                }

                var camera = GameObject.Find("Main Camera");
                if (camera != null)
                {
                    var followPsyche = camera.GetComponent<CameraFollowObj>();
                    if (followPsyche != null) followPsyche.enabled = true;
                }
                break;

            case 2: // Quiz
                if (QuizManager.Instance != null)
                {
                    QuizManager.Instance.ResetScore();
                }  

                isPysche = true;
                SceneManager.LoadScene("Quiz Question 1");
                break;

            case 3: // Credits
                SceneManager.LoadScene("Credits");
                break;

            case 4: // Back to Menu
                if (!isPysche && psyche != null)
                    psyche.SetActive(true);
                simulationCanvas.SetActive(false);
                interactiveCanvas.SetActive(false);
                if (quizScoreCanvas.activeSelf)
                    quizScoreCanvas.SetActive(false);
                menuCanvas.SetActive(true);
                break;

            case 5: // Comparison
                menuCanvas.SetActive(false);
                interactiveCanvas.SetActive(true);
                break;

            case 6:
                SceneManager.LoadScene("FighterJet");
                break;

            case 7:
                SceneManager.LoadScene("RoastChicken");
                break;

            case 8:
                SceneManager.LoadScene("PotatoPrototype");
                break;

            case 9:
                SceneManager.LoadScene("SolarSystemPrototype");
                break;
        }
    }
}
