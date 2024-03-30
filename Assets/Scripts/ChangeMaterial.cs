using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material newMaterial;
    public Material oMaterial;
    private Renderer rend;

 
    // OnCollisionEnter is called when the GameObject's collider makes contact with another collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with a GameObject tagged as "HUD"
        if (other.tag == "stone")
        {
            // Change the material to the new material
            rend = other.GetComponent<Renderer>();
            rend.material = newMaterial;
        }
    }

    // OnCollisionExit is called when the GameObject's collider loses contact with another collider
    void OnTriggerExit(Collider other)
    {
        // Check if the collision exits with a GameObject tagged as "HUD"
        if (other.tag == "stone")
        {
            rend = other.GetComponent<Renderer>();
            // Revert the material back to the original material
            rend.material = oMaterial;
        }
    }
}
