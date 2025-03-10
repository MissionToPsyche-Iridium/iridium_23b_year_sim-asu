using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RotateAround_Chicken : MonoBehaviour
{
    public Vector3 centerPoint = new Vector3(0.05323f, 1.0f, 2.14f); // The custom rotation center
    public Vector3 rotationAxis = Vector3.forward; // The axis to rotate around
    public int rotationSpeed = 1;  

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = RandomSpeedGenerator.GetRandomSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate around the specified point and axis
        transform.RotateAround(centerPoint, rotationAxis, rotationSpeed * Time.deltaTime);
    }
}

public static class RandomSpeedGenerator
{
    public static int GetRandomSpeed()
    {
        return UnityEngine.Random.Range(18, 37);
    }
}
