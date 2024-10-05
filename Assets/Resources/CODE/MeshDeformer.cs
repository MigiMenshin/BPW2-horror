using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MeshDeformer : MonoBehaviour
{
    private Mesh originalMesh;
    private Mesh deformedMesh;
    private Vector3[] originalVertices;
    private Vector3[] deformedVertices;

    public float amplitude = 1f; // Adjust the deformation intensity

    void Start()
    {
        originalMesh = GetComponent<MeshFilter>().mesh;
        deformedMesh = Instantiate(originalMesh);
        GetComponent<MeshFilter>().mesh = deformedMesh;

        originalVertices = originalMesh.vertices;
        deformedVertices = new Vector3[originalVertices.Length];
    }

    void Update()
    {
        float[] spectrum = new float[256];
        GetComponent<AudioSource>().GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 0; i < originalVertices.Length; i++)
        {
            Vector3 vertex = originalVertices[i];
            float noise = Mathf.PerlinNoise(vertex.x + Time.time, vertex.y + Time.time);
            vertex += vertex.normalized * noise * amplitude * spectrum[i % spectrum.Length];
            deformedVertices[i] = vertex;
        }

        deformedMesh.vertices = deformedVertices;
        deformedMesh.RecalculateNormals();
    }
}

