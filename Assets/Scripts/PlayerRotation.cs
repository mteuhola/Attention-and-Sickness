using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 90f;

    public int minRotateTime = 15;
    public int maxRotateTime = 25;
    
    public int rotationDirection = 1;

    private float degreesRotated;
    private bool isRotating;

    void Update()
    {
        if (isRotating)
        {
            RotateObject();
        }
        else
        {
            float timeToNextRotation = Random.Range(minRotateTime, maxRotateTime + 1);
            // Randomly determine rotation direction
            Invoke("StartRotation", timeToNextRotation); 
        }
    }

    public void StartRotation()
    {
        // Cancel any pending Invoke calls before starting a new rotation
        CancelInvoke("StartRotation");
    
        // Start rotating the object around its x-axis
        isRotating = true;
        
        // Randomly determine rotation direction
        rotationDirection = Random.Range(0, 2) == 0 ? 1 : -1; // 1 for forward, -1 for backward
    }

    private void RotateObject()
    {
        // Calculate the rotation amount for this frame
        var rotationAmount = rotationSpeed * Time.deltaTime;

        // Rotate the object around its x-axis
        transform.Rotate(Vector3.right * rotationAmount * rotationDirection);

        // Update the total degrees rotated
        degreesRotated += rotationAmount;

        // Check if one full rotation has been completed
        if (Mathf.Abs(degreesRotated) >= 360f)
        {
            // Reset rotation variables
            degreesRotated = 0f;
            isRotating = false;
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
    }
}
