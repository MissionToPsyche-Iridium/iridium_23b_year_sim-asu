using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;
    public int correctAnswers = 0;
    public static bool ReturnedFromEndOfQuiz = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void AddCorrectAnswer()
    {
        correctAnswers++;
    }

    public int GetScore()
    {
        return correctAnswers;
    }

    public void ResetScore()
    {
        correctAnswers = 0;
    }
}
