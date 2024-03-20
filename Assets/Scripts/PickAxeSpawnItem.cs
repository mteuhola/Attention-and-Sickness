using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxeSpawnItem : MonoBehaviour
{
public GameObject itemPrefab;
  private void OnCollisionEnter(Collision other)
    {
        // Check if the collision is with an asteroid
        if (other.gameObject.tag == "stone")
        {
            // Spawn the item prefab at the collision point
            Instantiate(itemPrefab, transform.position, transform.rotation);
        }
    }
}
