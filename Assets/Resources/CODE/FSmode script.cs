using UnityEngine;

public class FlashlightModesController : MonoBehaviour
{
    public Light flashlightLight;  // Reference to the Light component of the flashlight
    public float flashInterval = 0.5f; // Interval for flashing mode in seconds
    public float dimIntensity = 1.0f; // Intensity for dim mode
    public float brightIntensity = 2.0f; // Intensity for bright mode

    private int currentMode = 0; // Start with mode 0 (off)
    private bool isFlashActive = false; // Flag to track flashing state
    private float originalIntensity; // Store the original intensity of the flashlight

    void Start()
    {
        originalIntensity = flashlightLight.intensity; // Initialize with the light's original intensity
        flashlightLight.gameObject.SetActive(true); // Ensure the flashlight game object is active
        SetFlashlightMode(currentMode); // Set initial flashlight mode to off (0)
    }

    public void OnFlashlightTurnedOn()
    {
        CycleFlashlightMode(); // When turned on, cycle to the next mode
    }

    public void OnFlashlightTurnedOff()
    {
        // Ensure the flashlight is off when turned off
        if (isFlashActive)
        {
            CancelInvoke("ToggleFlash");
            isFlashActive = false;
        }
        SetFlashlightMode(0); // Always set to off mode when turned off
    }

    void Update()
    {
        if (flashlightLight.gameObject.activeSelf && (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.F)))
        {
            CycleFlashlightMode();
        }
    }

    public void CycleFlashlightMode()
    {
        // Cycle through modes: 0 (off), 1 (dim), 2 (off), 3 (flashing), 4 (off), 5 (bright), then loop back to 0
        currentMode = (currentMode + 1) % 6;
        SetFlashlightMode(currentMode);
    }

    void SetFlashlightMode(int mode)
    {
        // Disable flashing if changing modes
        if (isFlashActive)
        {
            CancelInvoke("ToggleFlash");
            isFlashActive = false;
        }

        // Set flashlight properties based on the mode
        switch (mode)
        {
            case 0: // Off mode
                flashlightLight.intensity = 0f; // Turn off the light
                break;
            case 1: // Dim mode
                flashlightLight.intensity = dimIntensity; // Set dim intensity
                break;
            case 2: // Off mode
                flashlightLight.intensity = 0f; // Turn off the light
                break;
            case 3: // Flashing mode
                flashlightLight.intensity = dimIntensity; // Ensure dim intensity during flashing
                isFlashActive = true;
                InvokeRepeating("ToggleFlash", 0f, flashInterval);
                break;
            case 4: // Off mode
                flashlightLight.intensity = 0f; // Turn off the light
                break;
            case 5: // Bright mode
                flashlightLight.intensity = brightIntensity; // Set to bright intensity
                break;
        }
    }

    void ToggleFlash()
    {
        flashlightLight.intensity = (flashlightLight.intensity > 0) ? 0f : dimIntensity;
    }
}
