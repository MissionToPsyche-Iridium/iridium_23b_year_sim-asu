//using System.Diagnostics;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

//[ExecuteAlways] // Run in Edit Mode too
public class OrbitalMotion : MonoBehaviour
{
    public Transform centerObject;
    public float semiMajorAxis = 10f;              
    public float orbitalPeriod = 10f;             
    public float orbitalEccentricity = 0.1f;       

    private float currentAngle = 0f;
    private float orbitalVelocity;
    private float semiMinorAxis;
    private Vector3 focusOffset;

    private float lastEditorTime;

    void OnEnable()
    {
        InitOrbit();
    }

    void Start()
    {
        InitOrbit();
    }

    void InitOrbit()
    {
        if (centerObject == null)
        {
            UnityEngine.Debug.LogWarning("No center object assigned for orbit.");
            return;
        }

        orbitalVelocity = 360f / orbitalPeriod;

        // Calculate the semi-minor axis: b² = a²(1 - e²)
        semiMinorAxis = semiMajorAxis * Mathf.Sqrt(1 - orbitalEccentricity * orbitalEccentricity);

        // Calculate how far the ellipse is offset from the center
        focusOffset = new Vector3(semiMajorAxis * orbitalEccentricity, 0, 0);

        lastEditorTime = (float)UnityEditor.EditorApplication.timeSinceStartup;
    }

    void Update()
    {
        if (centerObject == null) return;

        float deltaTime;

        // Use real delta time if playing, else use Editor time
        if (UnityEngine.Application.isPlaying)
        {
            deltaTime = Time.deltaTime;
        }
#if UNITY_EDITOR
        else
        {
            float currentTime = (float)UnityEditor.EditorApplication.timeSinceStartup;
            deltaTime = currentTime - lastEditorTime;
            lastEditorTime = currentTime;
        }
#endif
        orbitalVelocity = 360f / orbitalPeriod;
        currentAngle += orbitalVelocity * deltaTime;
        currentAngle %= 360f;
        float angleRad = currentAngle * Mathf.Deg2Rad;

        float x = semiMajorAxis * Mathf.Cos(angleRad);
        float z = semiMinorAxis * Mathf.Sin(angleRad);

        // Offset orbit by center
        Vector3 orbitPosition = new Vector3(x, 0, z) + centerObject.position;
        transform.position = orbitPosition;
    }
}
