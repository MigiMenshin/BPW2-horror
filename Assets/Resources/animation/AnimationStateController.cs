using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;
    int VelocityHash;
    int IsSprintingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        VelocityHash = Animator.StringToHash("Velocity");
        IsSprintingHash = Animator.StringToHash("IsSprinting");
    }

    // Update is called once per frame
    void Update()
    {
        // Handle input from joystick/controller
        float verticalInput = Input.GetAxis("Vertical");
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Joystick1Button1);

        // Update the velocity based on input
        if (Mathf.Abs(verticalInput) > 0.1f && velocity < 1.0f)
        {
            velocity += Time.deltaTime * acceleration;
        }
        else if (Mathf.Abs(verticalInput) <= 0.1f && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * deceleration;
        }

        // Clamp velocity to 0-1 range
        velocity = Mathf.Clamp(velocity, 0.0f, 1.0f);

        // Update the animator with the velocity parameter
        animator.SetFloat(VelocityHash, velocity);
        // Update the animator with the sprinting parameter
        animator.SetBool(IsSprintingHash, isSprinting);
    }
}
