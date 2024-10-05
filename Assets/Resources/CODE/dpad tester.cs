using UnityEngine;

public class DPadLogger : MonoBehaviour
{
    void Update()
    {
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown("joystick button " + i))
            {
                Debug.Log("Joystick button " + i + " is pressed.");
            }
        }
    }
}
