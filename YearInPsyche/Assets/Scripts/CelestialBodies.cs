using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class CelestialBodies : GravityObject
{
    public float radius = 1f;
    public float surfaceGravity = 9.8f;
    public Vector3 initialVelocity;
    public string bodyName = "Unnamed";

    private Transform meshHolder;
    public Rigidbody rb;

    public Vector3 velocity { get; private set; }
    public float mass { get; private set; }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody is required on CelestialBodies. Adding one automatically.");
            rb = gameObject.AddComponent<Rigidbody>();
        }

        rb.mass = mass;
        velocity = initialVelocity;
    }

    public void UpdateVelocity(CelestialBodies[] allBodies, float timeStep)
    {
        foreach (var otherBody in allBodies)
        {
            if (otherBody != this)
            {
                float sqrDst = (otherBody.rb.position - rb.position).sqrMagnitude;
                if (sqrDst == 0)
                {
                    Debug.LogWarning("Two celestial bodies are at the same position. Skipping gravitational calculation.");
                    continue;
                }

                Vector3 forceDir = (otherBody.rb.position - rb.position).normalized;
                Vector3 acceleration = forceDir * Universe.gravitationalConstant * otherBody.mass / sqrDst;
                velocity += acceleration * timeStep;
            }
        }
    }

    public void UpdateVelocity(Vector3 acceleration, float timeStep)
    {
        velocity += acceleration * timeStep;
    }

    public void UpdatePosition(float timeStep)
    {
        rb.MovePosition(rb.position + velocity * timeStep);
    }

    void OnValidate()
    {
        // Ensure radius is valid
        if (radius <= 0)
        {
            Debug.LogWarning("Radius must be greater than zero. Defaulting to 1.");
            radius = 1f;
        }

        // Calculate mass based on surface gravity and radius
        mass = surfaceGravity * radius * radius / Universe.gravitationalConstant;

        // Adjust visual scale
        meshHolder = transform; // Assume the object itself represents the visual
        if (meshHolder != null)
        {
            meshHolder.localScale = Vector3.one * radius * 2; // Diameter = 2 * radius for Unity spheres
        }

        // Update the object's name
        gameObject.name = bodyName;
    }

    public Rigidbody Rigidbody
    {
        get { return rb; }
    }

    public Vector3 Position
    {
        get { return rb.position; }
    }
}
