using System;
//using System.Diagnostics;

//using System.Diagnostics;
using UnityEngine;

public class PathRenderer : MonoBehaviour
{
    public float pointDistance = 0.1f;        // Minimum distance between path points
    public Color lineColor = Color.white;     // Line color
    public Transform centerObject;            // Sun (center of the orbit)
    private LineRenderer lineRenderer;
    private Vector3 previousPosition;
    private bool isFirstFrame = true;

    void Start()
    {
        // Create the material for the line renderer
        Material pathMaterial = new Material(Shader.Find("Unlit/Color"));
        pathMaterial.color = lineColor;

        // Add LineRenderer component to the object
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = pathMaterial;
        lineRenderer.positionCount = 0; // Initially no points
        lineRenderer.startWidth = 0.2f; // Set line width
        lineRenderer.endWidth = 0.2f;
        lineRenderer.useWorldSpace = true; // Use world space for correct position tracking

        // Make sure there's a center object (the Sun)
        if (centerObject == null)
        {
            Debug.LogError("No center object (Sun) assigned for orbit path!");
        }
    }

    void Update()
    {
        // If no center object, exit
        if (centerObject == null) return;

        // If it's the first frame, add the initial position
        if (isFirstFrame)
        {
            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, transform.position);
            previousPosition = transform.position;
            isFirstFrame = false;
        }
        else
        {
            // Check if the object has moved beyond the pointDistance threshold
            if (Vector3.Distance(transform.position, previousPosition) >= pointDistance)
            {
                // Increase the position count (add a new point to the path)
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);
                previousPosition = transform.position; // Update the previous position
            }
        }


    }
}
