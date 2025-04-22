using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;
    public static bool ReturnedFromEndOfQuiz = false;

    private HashSet<int> answeredQuestions = new HashSet<int>();

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

    public void AddCorrectAnswer(int questionIndex)
    {
        answeredQuestions.Add(questionIndex); // HashSet prevents duplicates
    }

    public int GetScore()
    {
        return answeredQuestions.Count;
    }

    public void ResetScore()
    {
        answeredQuestions.Clear();
    }

    public bool HasAnswered(int questionIndex)
    {
        return answeredQuestions.Contains(questionIndex);
    }
}
