using UnityEngine;

public class AnimationLayerController : MonoBehaviour
{
    [Tooltip("Drag your Animator component here.")]
    public Animator animator; // Assign this in the Inspector

    public int activeLayerIndex = 0; // Index of the layer to activate

    void Start()
    {
        if (animator == null)
        {
            Debug.LogError("Animator component is not assigned. Please assign it in the Inspector.");
            return;
        }

        // Initialize the layers
        UpdateAnimationLayers();
    }

    void Update()
    {
        // Example input handling: Press keys to switch layers
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActiveLayer(0); // Set layer 0 as active
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActiveLayer(1); // Set layer 1 as active
        }
        // Add more keys if you have more layers
    }

    public void SetActiveLayer(int layerIndex)
    {
        if (animator == null) return;

        // Ensure the layer index is within valid range
        activeLayerIndex = Mathf.Clamp(layerIndex, 0, animator.layerCount - 1);

        // Update the animation layers based on the new active layer
        UpdateAnimationLayers();
    }

    private void UpdateAnimationLayers()
    {
        if (animator == null) return;

        // Loop through all layers and set the weight
        for (int i = 0; i < animator.layerCount; i++)
        {
            float weight = (i == activeLayerIndex) ? 1.0f : 0.0f;
            animator.SetLayerWeight(i, weight);
        }
    }
}

