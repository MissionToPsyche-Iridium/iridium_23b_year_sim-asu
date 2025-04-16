using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Public fields to assign buttons in the inspector
    // main menu UI elements
    public Button simulation;
    public Button quiz;
    public Button comparison;
    public Button credits;
    public Button back;
    public GameObject menuCanvas;

    // comparison menu UI elements
    public Button fighterJet;
    public Button roastChicken;
    public Button potato;
    public GameObject interactiveCanvas;

    private int quizzes = 3;
    private int currentQuizIndex = 0;
    private bool isQuizLoaded = false;

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

    }

    void OnButtonClicked(int buttonNumber)
    {
        // Insert your button-specific functionality here,
        // e.g., loading a scene, updating UI elements, etc.
        //menuCanvas.SetActive(false);

        switch (buttonNumber)
        {
            case 1:
                break;
            case 2:
                // Go through all the Quiz questions
                SceneManager.LoadScene("Quiz Question 1");
                break;
            case 3:
                SceneManager.LoadScene("Credits");
                break;
            case 4:
                // go back to main menu
                interactiveCanvas.SetActive(false);
                menuCanvas.SetActive(true);
                break;
            case 5:
                // go to comparison menu
                menuCanvas.SetActive(false);
                interactiveCanvas.SetActive(true);
                break;
            case 6:
                // load fighter jet scene
                SceneManager.LoadScene("FighterJet");
                break;
            case 7:
                // load roast chicken scene
                SceneManager.LoadScene("RoastChicken");
                break;
            case 8:
                // load potato scene
                SceneManager.LoadScene("PotatoPrototype");
                break;
            default:
                break;
        }
    }


    IEnumerator StartQuizSequence()
    {
        menuCanvas.SetActive(false);
        interactiveCanvas.SetActive(true);

        for (currentQuizIndex = 1; currentQuizIndex <= quizzes; currentQuizIndex++)
        {
            string quizScene = $"Quiz Question {currentQuizIndex}";
            SceneManager.LoadScene(quizScene, LoadSceneMode.Additive);

            // Wait for the quiz to be completed before proceeding
            yield return new WaitUntil(() => QuizCompleted());

            SceneManager.UnloadSceneAsync(quizScene);
        }

        // Return to menu after completing all quizzes
        menuCanvas.SetActive(true);
        interactiveCanvas.SetActive(false);
    }

    bool QuizCompleted()
    {
        // Implement logic to check if a quiz is completed
        // This could be based on a button click, a score system, or a message from the quiz scene
        return Input.GetKeyDown(KeyCode.Space); // Temporary test: press Space to continue
    }
}
