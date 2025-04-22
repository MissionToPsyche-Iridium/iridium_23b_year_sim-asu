using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackAndNextButtons : MonoBehaviour
{
    public int minIndex = 0;
    public int maxIndex = 16;

    //void Start()
    //{
    //    UnityEngine.Debug.Log("Current Scene Index: " + SceneManager.GetActiveScene().buildIndex);
    //}

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
