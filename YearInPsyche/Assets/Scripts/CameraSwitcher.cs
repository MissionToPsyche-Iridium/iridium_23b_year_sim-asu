using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera; // The main camera following the planet (Psyche)
    public Camera systemCamera; // The camera showing the entire solar system

    void Start()
    {
        // Ensure the main camera starts active, and system camera is inactive
        SwitchToMainCamera();
    }

    void Update()
    {
        // Switch to main camera when 'M' is pressed
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SwitchToMainCamera();
        }

        // Switch to system camera when 'S' is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchToSystemCamera();
        }
    }

    void SwitchToMainCamera()
    {
        mainCamera.enabled = true;
        systemCamera.enabled = false;
    }

    void SwitchToSystemCamera()
    {
        mainCamera.enabled = false;
        systemCamera.enabled = true;
    }
}
