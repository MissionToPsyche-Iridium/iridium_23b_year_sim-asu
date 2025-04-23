using UnityEngine;
using UnityEngine.SceneManagement;

public class MultipleChoiceNoAnimation : MonoBehaviour
{
    public GameObject QuestionBox;
    public GameObject Correct;
    public GameObject Incorrect;
    public void Start()
    {
        QuestionBox.SetActive(true);
        Correct.SetActive(false);
        Incorrect.SetActive(false);
    }

    // Update is called once per frame
    public void correct()
    {
        //UnityEngine.Debug.Log("Correct! Question #" + SceneManager.GetActiveScene().buildIndex + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        QuestionBox.SetActive(false);
        Correct.SetActive(true);

        if (QuizManager.Instance == null)
        {
            UnityEngine.Debug.LogError("QuizManager.Instance is NULL");
        }

        QuizManager.Instance.AddCorrectAnswer(SceneManager.GetActiveScene().buildIndex);
        UnityEngine.Debug.Log("Scores: " + QuizManager.Instance.GetScore());
    }
    public void incorrect()
    {
        QuestionBox.SetActive(false);
        Incorrect.SetActive(true);
    }
}
