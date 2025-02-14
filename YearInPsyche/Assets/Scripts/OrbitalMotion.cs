using UnityEngine;

public class OrbitalMotion : MonoBehaviour
{
    public Transform centerObject; 
    public float semiMajorAxis = 10f;
    public float orbitalPeriod = 10f;
    public float orbitalEccentricity = 0.1f;

    private float currentAngle = 0f;
    private float orbitalVelocity; 

    void Start()
    {
        orbitalVelocity = 360f / orbitalPeriod;
    }

    void Update()
    {
        currentAngle += orbitalVelocity * Time.deltaTime;
        currentAngle %= 360f; 

        float angleRad = currentAngle * Mathf.Deg2Rad;

        float x = semiMajorAxis * Mathf.Cos(angleRad) * (1 - orbitalEccentricity);
        float z = semiMajorAxis * Mathf.Sin(angleRad) * Mathf.Sqrt(1 - orbitalEccentricity * orbitalEccentricity);

        transform.position = centerObject.position + new Vector3(x, 0, z);
        //transform.LookAt(centerObject);

        //transform.rotation = Quaternion.Euler(30f, currentAngle, 0);
    }
}
