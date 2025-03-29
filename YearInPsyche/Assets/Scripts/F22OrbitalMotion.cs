
using UnityEngine;

public class F22OrbitalMotion : MonoBehaviour
{
    public Transform psyche; // Psyche as the center object
    public float semiMajorAxis = 10f; // Radius of orbit (distance from Psyche)
    public float orbitalPeriod = 10f; // Time for one full orbit
    public float orbitalEccentricity = 0.1f; // Orbital eccentricity (if you want elliptical orbit)

    private float orbitalVelocity; // Angular velocity for the orbit
    private float semiMinorAxis; // Semi-minor axis for elliptical orbits
    private float currentAngle = 0f; // Keeps track of the angle in the orbit
    private Vector3 orbitCenter; // Center position for the orbit

    void Start()
    {
        if (psyche == null)
        {
            Debug.LogError("No center object (Psyche) assigned for orbit.");
            return;
        }

        // Compute angular velocity (degrees per second)
        orbitalVelocity = 360f / orbitalPeriod;

        // Calculate the semi-minor axis for an elliptical orbit: b² = a²(1 - e²)
        semiMinorAxis = semiMajorAxis * Mathf.Sqrt(1 - orbitalEccentricity * orbitalEccentricity);

        orbitCenter = psyche.position; // Psyche's center position
    }

    void Update()
    {
        if (psyche == null) return;

        // Update the current angle of the orbit
        currentAngle += orbitalVelocity * Time.deltaTime;
        currentAngle %= 360f; // Keep the angle between 0 and 360 degrees

        // Convert current angle to radians
        float angleRad = currentAngle * Mathf.Deg2Rad;

        // Calculate orbital position based on semi-major and semi-minor axes
        Vector3 orbitalOffset = new Vector3(
            semiMajorAxis * Mathf.Cos(angleRad), // X stays fixed as the center of orbit
            semiMinorAxis * Mathf.Sin(angleRad), // Y position is based on orbit angle
            0f // Z stays fixed as well
        );

        // Update the position of the F-22 around Psyche
        transform.position = psyche.position + orbitalOffset;

        // We don't need to update rotation towards Psyche, just allow normal orbit rotation
        // You can rotate the F-22 model freely, or leave it static.
    }
}
