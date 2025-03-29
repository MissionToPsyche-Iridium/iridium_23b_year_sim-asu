//using System.Diagnostics;
using UnityEngine;

public class OrbitalMotion : MonoBehaviour
{
    public Transform centerObject;
    public float semiMajorAxis = 10f; // Longest radius of the ellipse
    public float orbitalPeriod = 10f; // Time to complete one orbit
    public float orbitalEccentricity = 0.1f; // 0 = circle, closer to 1 = more elliptical

    private float currentAngle = 0f;
    private float orbitalVelocity;
    private float semiMinorAxis;
    private Vector3 focusOffset;

    void Start()
    {
        if (centerObject == null)
        {
            Debug.LogError("No center object assigned for orbit.");
            return;
        }

        orbitalVelocity = 360f / orbitalPeriod;

        // Calculate the semi-minor axis using the formula: b² = a²(1 - e²)
        semiMinorAxis = semiMajorAxis * Mathf.Sqrt(1 - orbitalEccentricity * orbitalEccentricity);

        focusOffset = new Vector3(semiMajorAxis * orbitalEccentricity, 0, 0);
    }

    void Update()
    {
        if (centerObject == null) return;

        // Update angle in radians
        currentAngle += orbitalVelocity * Time.deltaTime;
        currentAngle %= 360f;
        float angleRad = currentAngle * Mathf.Deg2Rad;

        // Compute orbital position based on ellipse equation
        float x = semiMajorAxis * Mathf.Cos(angleRad);
        float z = semiMinorAxis * Mathf.Sin(angleRad);

        // Offset the orbit by the focus shift
        Vector3 orbitPosition = new Vector3(x, 0, z) + (centerObject.position - focusOffset);

        // Apply position and face the center
        transform.position = orbitPosition;
        transform.LookAt(centerObject);
    }
}
