using UnityEngine;

public class FlashlighttiltController : MonoBehaviour
{
    public Transform flashlight; // Assign the flashlight GameObject in the Inspector
    public float tiltSpeed = 30.0f; // Tilt speed for responsiveness
    public float maxTiltAngle = 60.0f; // Maximum tilt angle in degrees

    private float currentTiltY = 0.0f; // Track current Y-axis tilt

    void Update()
    {
        // Check if the joystick button for tilt up is pressed (PS5: Joystick1Button4, Xbox: X)
        if (Input.GetKey(KeyCode.Joystick1Button0))
        {
            TiltFlashlight(-1); // Tilt up
        }
        // Check if the joystick button for tilt down is pressed (PS5: Joystick1Button5, Xbox: Y)
        else if (Input.GetKey(KeyCode.Joystick1Button3))
        {
            TiltFlashlight(1); // Tilt down
        }
    }

    void TiltFlashlight(int direction)
    {
        // Calculate the new tilt angle
        float newTiltY = currentTiltY + direction * tiltSpeed * Time.deltaTime;

        // Clamp the tilt angle within the specified range
        newTiltY = Mathf.Clamp(newTiltY, -maxTiltAngle, maxTiltAngle);

        // Apply the tilt rotation to the flashlight
        if (flashlight != null)
        {
            flashlight.localRotation = Quaternion.Euler(newTiltY, flashlight.localEulerAngles.y, flashlight.localEulerAngles.z);

            // Update current tilt angle for Y-axis
            currentTiltY = newTiltY;
        }
    }
}
