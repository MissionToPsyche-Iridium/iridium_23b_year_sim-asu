using UnityEngine;

public class FloatingExitScript : MonoBehaviour
{
    public float floatSpeed = 1.0f;       // Speed of the float movement
    public float floatAmplitude = 0.5f;   // Amplitude of the float movement
    public float rotationSpeed = 50.0f;   // Speed of rotation

    private Vector3 startPos;
    private Camera mainCamera;

    void Start()
    {
        startPos = transform.position;  // Store the original position
        mainCamera = Camera.main;        // Get the main camera
    }

    void Update()
    {
        // Floating up and down movement
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        // Slow rotation around the Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Raycast to detect if the object is clicked
        if (Input.GetMouseButtonDown(0))  // Left-click
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)  // If the clicked object is the Exit Sign
                {
                    // Exit the application
                    Application.Quit();

#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#endif
                }
            }
        }
    }
}
