using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpinCompare : MonoBehaviour
{
    public RotateAround_Psyche asteroidRotationScript; // Reference to asteroid rotation script
    public RotateAround_Chicken chickenRotationScript; // Reference to chicken rotation script
    public TMP_Text comparisonText; // UI text to display result

    public float targetDelta = 0.5f; // Allowable difference in speed
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (asteroidRotationScript != null && chickenRotationScript != null && comparisonText != null)
        {
            float asteroidSpeed = asteroidRotationScript.rotationSpeed;
            float chickenSpeed = chickenRotationScript.rotationSpeed;
            float difference = Mathf.Round(chickenSpeed / 0.024f);
            float rpm = (float)System.Math.Round(chickenSpeed * 60 / 360, 1);

            // Check if the asteroid's speed is within the tolerance of the chicken's speed
            if (asteroidSpeed - chickenSpeed < (targetDelta * -1))
            {
                comparisonText.text = "Too Slow!";
            }
            else if (asteroidSpeed - chickenSpeed < targetDelta)
            {
                comparisonText.text = "You did it! The chicken is spinning at " + chickenSpeed + "°/s or " + rpm + " rpm. \n This is about " + difference + " times faster than Psyche's actual rotation speed.";
            } 
            else
            {
                comparisonText.text = "Too Fast!";
            }
        }
    }
}
