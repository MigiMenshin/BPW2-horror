using UnityEngine;

public class CharacterTilt : MonoBehaviour
{
    public Transform torsoBone; // Assign the torso bone in the Inspector
    public float tiltSpeed = 2.0f;
    public float maxTiltAngle = 30.0f;

    private float currentTilt = 0.0f;

    void Update()
    {
        // Get the input from the right stick's vertical axis
        float rightStickVertical = Input.GetAxis("RightStickVertical"); // Ensure your input axis is configured

        // Calculate the new tilt angle
        currentTilt += rightStickVertical * tiltSpeed * Time.deltaTime;

        // Clamp the tilt angle to avoid unnatural rotations
        currentTilt = Mathf.Clamp(currentTilt, -maxTiltAngle, maxTiltAngle);

        // Apply the tilt rotation to the torso
        torsoBone.localRotation = Quaternion.Euler(currentTilt, 0, 0);
    }
}
