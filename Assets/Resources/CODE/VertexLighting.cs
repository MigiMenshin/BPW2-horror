using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class VertexLighting : MonoBehaviour
{
    public Light lightSource;
    public Color baseColor = Color.white;

    void Start()
    {
        if (lightSource == null)
        {
            Debug.LogError("Light source not assigned.");
            return;
        }

        ApplyVertexLighting();
    }

    void ApplyVertexLighting()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;

        if (mesh == null)
        {
            Debug.LogError("Mesh not found.");
            return;
        }

        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        Color[] colors = new Color[vertices.Length];

        Vector3 lightDir = -lightSource.transform.forward;

        for (int i = 0; i < vertices.Length; i++)
        {
            float NdotL = Mathf.Max(0, Vector3.Dot(normals[i], lightDir));
            colors[i] = baseColor * lightSource.color * NdotL;
        }

        mesh.colors = colors;
    }
}
