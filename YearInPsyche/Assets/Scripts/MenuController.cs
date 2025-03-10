using System.Diagnostics;
using UnityEngine;
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

    void Start()
    {
        // Add listeners to each button's onClick event
        simulation.onClick.AddListener(() => OnButtonClicked(1));
        quiz.onClick.AddListener(() => OnButtonClicked(2));
        exit.onClick.AddListener(() => OnButtonClicked(3));
        back.onClick.AddListener(() => OnButtonClicked(4));
    }

    // This method handles button click events
    void OnButtonClicked(int buttonNumber)
    {
        // Insert your button-specific functionality here,
        // e.g., loading a scene, updating UI elements, etc.
        menuCanvas.SetActive(false);
        interactiveCanvas.SetActive(true);

        switch (buttonNumber)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                menuCanvas.SetActive(true);
                interactiveCanvas.SetActive(false);
                break;
            default:
                break;
        }
    }
}
