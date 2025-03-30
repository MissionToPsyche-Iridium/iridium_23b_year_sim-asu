using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Public fields to assign buttons in the inspector
    public Button simulation;
    public Button quiz;
    public Button exit;
    public Button back;
    public GameObject menuCanvas;
    public GameObject interactiveCanvas;

    private int quizzes = 3;
    private int currentQuizIndex = 0;
    private bool isQuizLoaded = false;

    void Start()
    {
        simulation.onClick.AddListener(() => OnButtonClicked(1));
        quiz.onClick.AddListener(() => OnButtonClicked(2));
        exit.onClick.AddListener(() => OnButtonClicked(3));
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
                SceneManager.LoadScene("Quiz Question 1", LoadSceneMode.Additive);
                break;
            case 3:
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif
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
