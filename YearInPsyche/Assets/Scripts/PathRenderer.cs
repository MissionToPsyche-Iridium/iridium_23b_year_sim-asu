//using System.Diagnostics;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

[ExecuteAlways]
[RequireComponent(typeof(LineRenderer))]
public class PathRenderer : MonoBehaviour
{
    public float pointDistance = 0.1f;
    public Color lineColor = new Color(1f, 1f, 1f, 0.5f);
    public Transform centerObject;
    public float offset = 0.0f;

    private LineRenderer lineRenderer;
    private Vector3 previousPosition;
    private bool isFirstFrame = true;

    void OnEnable()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SetupLineRenderer();
    }

    void OnValidate()
    {
        if (lineRenderer != null)
        {
            UpdateColor();
        }
    }

    void SetupLineRenderer()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.useWorldSpace = true;
        lineRenderer.positionCount = 0;

        Shader shader = Shader.Find("Legacy Shaders/Particles/Alpha Blended");
        if (shader == null)
        {
            Debug.LogError("Shader not found! Use Legacy Shaders/Particles/Alpha Blended.");
            return;
        }

        Material mat = new Material(shader);
        mat.color = lineColor;
        lineRenderer.material = mat;

        UpdateColor();

        previousPosition = GetPathPosition();
        isFirstFrame = true;
    }

    void UpdateColor()
    {
        if (lineRenderer != null)
        {
            lineRenderer.startColor = lineColor;
            lineRenderer.endColor = lineColor;
            if (lineRenderer.material != null)
                lineRenderer.material.color = lineColor;
        }
    }

    Vector3 GetPathPosition()
    {
        Vector3 pos = transform.position;
        pos.x += offset;
        return pos;
    }

    void Update()
    {
        if (centerObject == null) return;

        UpdateColor();

        Vector3 currentPos = GetPathPosition();

        if (!UnityEngine.Application.isPlaying)
        {
            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, currentPos);
            return;
        }

        if (isFirstFrame)
        {
            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, currentPos);
            previousPosition = currentPos;
            isFirstFrame = false;
        }
        else
        {
            if (Vector3.Distance(currentPos, previousPosition) >= pointDistance)
            {
                int nextIndex = lineRenderer.positionCount;
                lineRenderer.positionCount = nextIndex + 1;
                lineRenderer.SetPosition(nextIndex, currentPos);
                previousPosition = currentPos;
            }
        }
    }
}
