using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMotion : MonoBehaviour
{
    public Transform rig;
    public float movementThreshold = 0.1f;

    
    void Update()
    {
    Vector2 joystickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    if (joystickInput.magnitude < movementThreshold)
        {
            // If joystick input is below the threshold, set motion to zero
            rig.Translate(Vector3.zero);
        }
    }
}