using UnityEngine;

[ExecuteAlways] // Ensures the script runs in Edit Mode & Play Mode
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class RingMeshGenerator : MonoBehaviour
{
    [Header("Ring Settings")]
    public float innerRadius = 1.2f;
    public float outerRadius = 2.25f;
    public int segments = 64;
    public Material ringMaterial;

    private MeshFilter meshFilter;
    private Mesh mesh;

    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        GenerateRing();
    }

    void OnValidate() // Runs when values change in the Inspector
    {
        GenerateRing();
    }

    public void GenerateRing()
    {
        if (meshFilter == null) meshFilter = GetComponent<MeshFilter>();
        if (mesh == null) mesh = new Mesh();
        mesh.name = "Ring Mesh";

        int vertexCount = (segments + 1) * 2;
        Vector3[] vertices = new Vector3[vertexCount];
        Vector2[] uv = new Vector2[vertexCount];
        int[] triangles = new int[segments * 6];

        float angleStep = 2 * Mathf.PI / segments;

        for (int i = 0; i <= segments; i++)
        {
            float angle = angleStep * i;
            float cosA = Mathf.Cos(angle);
            float sinA = Mathf.Sin(angle);

            vertices[i * 2] = new Vector3(cosA * innerRadius, 0, sinA * innerRadius);
            vertices[i * 2 + 1] = new Vector3(cosA * outerRadius, 0, sinA * outerRadius);

            uv[i * 2] = new Vector2(0, i / (float)segments);
            uv[i * 2 + 1] = new Vector2(1, i / (float)segments);

            if (i < segments)
            {
                int startIndex = i * 6;
                int innerCurrent = i * 2;
                int outerCurrent = i * 2 + 1;
                int innerNext = (i + 1) * 2;
                int outerNext = (i + 1) * 2 + 1;

                triangles[startIndex] = innerCurrent;
                triangles[startIndex + 1] = outerNext;
                triangles[startIndex + 2] = outerCurrent;

                triangles[startIndex + 3] = innerCurrent;
                triangles[startIndex + 4] = innerNext;
                triangles[startIndex + 5] = outerNext;
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        meshFilter.mesh = mesh;

        if (ringMaterial != null)
            GetComponent<MeshRenderer>().material = ringMaterial;
    }
}
