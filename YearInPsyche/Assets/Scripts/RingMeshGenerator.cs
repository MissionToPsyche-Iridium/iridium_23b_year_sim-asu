using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class RingMeshGenerator : MonoBehaviour
{
    [Header("Ring Settings")]
    public float innerRadius = 1.2f;  // Inner radius of the ring
    public float outerRadius = 2.25f; // Outer radius of the ring
    public int segments = 64;         // Number of segments in the ring
    public Material ringMaterial;     // Material for the ring

    void Start()
    {
        GenerateRing();
    }

    void GenerateRing()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();

        int vertexCount = (segments + 1) * 2; // Two vertices per segment
        Vector3[] vertices = new Vector3[vertexCount];
        Vector2[] uv = new Vector2[vertexCount];
        int[] triangles = new int[segments * 6]; // Six indices per quad

        float angleStep = 360f / segments;

        // Generate vertices and UVs
        for (int i = 0; i <= segments; i++)
        {
            float angle = Mathf.Deg2Rad * angleStep * i;

            // Calculate inner and outer vertices
            float xInner = Mathf.Cos(angle) * innerRadius;
            float zInner = Mathf.Sin(angle) * innerRadius;
            float xOuter = Mathf.Cos(angle) * outerRadius;
            float zOuter = Mathf.Sin(angle) * outerRadius;

            // Inner vertex
            vertices[i * 2] = new Vector3(xInner, 0, zInner);
            uv[i * 2] = new Vector2(0, i / (float)segments);

            // Outer vertex
            vertices[i * 2 + 1] = new Vector3(xOuter, 0, zOuter);
            uv[i * 2 + 1] = new Vector2(1, i / (float)segments);

            // Create triangles for this segment
            if (i < segments)
            {
                int startIndex = i * 6;
                int innerCurrent = i * 2;
                int outerCurrent = i * 2 + 1;
                int innerNext = (i + 1) * 2;
                int outerNext = (i + 1) * 2 + 1;

                // Triangle 1
                triangles[startIndex] = innerCurrent;
                triangles[startIndex + 1] = outerNext;
                triangles[startIndex + 2] = outerCurrent;

                // Triangle 2
                triangles[startIndex + 3] = innerCurrent;
                triangles[startIndex + 4] = innerNext;
                triangles[startIndex + 5] = outerNext;
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;

        if (ringMaterial != null)
        {
            GetComponent<MeshRenderer>().material = ringMaterial;
        }
    }



}