using UnityEngine;

public class Psyche_Spin_Transition : MonoBehaviour
{
    public Vector3 centerPoint = new Vector3(0.05323f, 1.0f, 2.14f); // The custom rotation center
    public Vector3 rotationAxis = Vector3.forward; // The axis to rotate around
    public int rotationSpeed = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate around the specified point and axis
        transform.RotateAround(centerPoint, rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
