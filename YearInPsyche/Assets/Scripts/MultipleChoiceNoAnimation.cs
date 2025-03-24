using UnityEngine;

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
        QuestionBox.SetActive(false);
        Correct.SetActive(true);
    }
    public void incorrect()
    {
        QuestionBox.SetActive(false);
        Incorrect.SetActive(true);
    }
}
