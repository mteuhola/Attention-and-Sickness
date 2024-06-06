using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed;

    public int minRotateTime = 15;
    public int maxRotateTime = 25;
    
    public int rotationDirection = 1;

    private float degreesRotated, maximumRotation;
    private bool isRotating;

    private Vector3 rotationAxis = Vector3.right;

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
        switch (Random.Range(0, 6))
        {
            case 0:
                rotationAxis = Vector3.up + Vector3.right; //rotation around yx-axis
                maximumRotation = 255f;
                break;
            case 1:
                rotationAxis = Vector3.right + Vector3.forward; //rotation around xz-axis
                maximumRotation = 255f;
                break;
            case 2:
                rotationAxis = Vector3.up + Vector3.forward; //rotation around yz-axis
                maximumRotation = 255f;
                break;
            case 3:
                rotationAxis = Vector3.up; //rotation around y-axis
                maximumRotation = 360f;
                break;
            case 4:
                rotationAxis = Vector3.right; //rotation around x-axis
                maximumRotation = 360f;
                break;
            case 5:
                rotationAxis = Vector3.forward; //rotation around z-axis
                maximumRotation = 360f;
                break;
            default:
                rotationAxis = Vector3.right;
                maximumRotation = 360f;
                break;
        }
    }

    private void RotateObject()
    {
        // Calculate the rotation amount for this frame
        var rotationAmount = rotationSpeed * Time.deltaTime;

        // Rotate the object around its x-axis
        transform.Rotate(rotationAxis * rotationAmount * rotationDirection);

        // Update the total degrees rotated
        degreesRotated += rotationAmount;

        // Check if one full rotation has been completed
        if (Mathf.Abs(degreesRotated) >= maximumRotation)
        {
            // Reset rotation variables
            degreesRotated = 0f;
            isRotating = false;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
