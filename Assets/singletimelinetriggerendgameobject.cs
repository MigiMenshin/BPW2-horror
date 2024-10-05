using UnityEngine;

public class DeactivateOnSignal : MonoBehaviour
{
    // This method can be called as a signal to deactivate the GameObject
    public void DeactivateGameObject()
    {
        // Deactivate the GameObject this script is attached to
        gameObject.SetActive(false);
    }
}
