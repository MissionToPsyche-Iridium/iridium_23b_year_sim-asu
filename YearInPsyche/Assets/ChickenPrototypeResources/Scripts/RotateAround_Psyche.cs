using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RotateAround_Psyche : MonoBehaviour
{
    public Vector3 centerPoint = new Vector3(1.52f, 0, -4.7f); // The custom rotation center
    public Vector3 rotationAxis = Vector3.forward; // The axis to rotate around
    public float rotationSpeed = 0.5f;  


    public Slider speedSlider;
    public TMP_Text rotationSpeedText;
    public TMP_Text dayLengthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speedSlider != null)
        {
            rotationSpeed = Mathf.Pow(speedSlider.value, 2);
            float dayLength = 360f / rotationSpeed / 3600f; // Convert to hours
            if (rotationSpeedText != null)
            {
                if (rotationSpeed < 0.00001) 
                {
                    rotationSpeedText.text = $"Rotation Speed: {rotationSpeed:F8}°/s";
                }
                else
                {
                    rotationSpeedText.text = $"Rotation Speed: {rotationSpeed:F5}°/s";
                }
            }
            if (dayLengthText != null)
            {
                if (dayLength < 1)
                {
                    dayLength = dayLength * 60; // convert to minutes
                    if (dayLength < 1) 
                    {
                        dayLength = dayLength * 60; // convert to seconds
                        dayLengthText.text = $"Length of a day: {dayLength:F2} seconds";
                    }
                    else
                    {
                        dayLengthText.text = $"Length of a day: {dayLength:F2} minutes";
                    }
                }
                else 
                {
                    dayLengthText.text = $"Length of a day: {dayLength:F2} hours";
                }
            }

        }
        // Rotate around the specified point and axis
        transform.RotateAround(centerPoint, rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
