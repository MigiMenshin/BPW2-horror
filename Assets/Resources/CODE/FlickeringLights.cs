using System.Collections;
using UnityEngine;

public class FlickeringGameObject : MonoBehaviour
{
    public float minFlickerTime = 0.1f;  // Minimum time between flickers
    public float maxFlickerTime = 0.5f;  // Maximum time between flickers
    public bool startActive = true;      // Whether the object should start active

    private void Start()
    {
        // Set the initial active state of the GameObject
        gameObject.SetActive(startActive);

        // Start the flicker coroutine
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        while (true)
        {
            // Randomly decide the time before the GameObject flickers again
            float flickerDuration = Random.Range(minFlickerTime, maxFlickerTime);

            // Wait for the randomly chosen time
            yield return new WaitForSeconds(flickerDuration);

            // Toggle the GameObject's active state
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
