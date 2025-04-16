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
        // Insert your button-specific functionality here,
        // e.g., loading a scene, updating UI elements, etc.
        //menuCanvas.SetActive(false);

        switch (buttonNumber)
        {
            case 1:
                SceneManager.LoadScene("SolarSystemPrototype");
                break;
            default:
                break;
        }
    }
}
