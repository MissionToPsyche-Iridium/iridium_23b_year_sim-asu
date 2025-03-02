using UnityEngine;

public class StartCamera : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(490, -1, -8);
    public Quaternion targetRotation = Quaternion.Euler(0, 360, 0);
    public float moveSpeed = 500f;     // Adjust as needed
    public float rotateSpeed = 30f;  // Increase for a faster rotation
    private bool reachedPosition = false;

    void Start()
    {
        // Set the starting position and rotation
        transform.position = new Vector3(4900, 0, -10);
        transform.rotation = Quaternion.Euler(0, 290, 0);
    }

    void Update()
    {
        // Stage 1: Move to target position
        if (!reachedPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            // Use a small threshold for floating point comparisons if needed:
            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                reachedPosition = true;
            }
        }
        // Stage 2: Once position is reached, rotate to target rotation
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            // Optionally, check if rotation is complete:
            // if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f) { ... }
        }
    }
}
