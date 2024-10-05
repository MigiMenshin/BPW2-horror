using UnityEngine;
using UnityEngine.InputSystem;

public class InputDetection : MonoBehaviour
{
    // Reference to the Input Actions asset if needed (optional)
    public InputActionAsset inputActions;

    private void OnEnable()
    {
        // Enable the Input Action asset if you're using one
        if (inputActions != null)
        {
            foreach (var map in inputActions.actionMaps)
            {
                map.Enable();
            }
        }
    }

    private void OnDisable()
    {
        // Disable the Input Action asset if you're using one
        if (inputActions != null)
        {
            foreach (var map in inputActions.actionMaps)
            {
                map.Disable();
            }
        }
    }

    private void Update()
    {
        // Detect Keyboard Input
        if (Keyboard.current != null)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Debug.Log("Space key pressed");
            }
            if (Keyboard.current.enterKey.wasPressedThisFrame)
            {
                Debug.Log("Enter key pressed");
            }
        }

        // Detect Gamepad Input
        if (Gamepad.current != null)
        {
            if (Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                Debug.Log("Button South (usually 'X' on PS3) pressed");
            }
            if (Gamepad.current.leftStickButton.wasPressedThisFrame)
            {
                Debug.Log("Left Stick Button pressed");
            }
        }

        // Detect Mouse Input
        if (Mouse.current != null)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Debug.Log("Left mouse button pressed");
            }
            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                Debug.Log("Right mouse button pressed");
            }
        }

        // Detect other input devices
        foreach (var device in InputSystem.devices)
        {
            // Log all detected devices
            Debug.Log("Device detected: " + device.displayName);
        }
    }
}
