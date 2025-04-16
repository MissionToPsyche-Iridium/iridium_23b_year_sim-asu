using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackAndNextButtons : MonoBehaviour
{
    public int minIndex = 1;
    public int maxIndex = 15;
    public void GoBack()
    {
        if (SceneManager.GetActiveScene().buildIndex > minIndex)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void GoNext()
    {
        if (SceneManager.GetActiveScene().buildIndex < maxIndex)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
