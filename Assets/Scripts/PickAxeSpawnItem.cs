using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxeSpawnItem : MonoBehaviour
{
public GameObject itemPrefab;
public AudioSource pickSound;
public int pickHitCount = 0;

  private void OnCollisionEnter(Collision other)
    {
        // Check if the collision is with an asteroid
        if (other.gameObject.tag == "stone")
        {
            pickSound.Play();
            // Spawn the item prefab at the collision point
            Instantiate(itemPrefab, transform.position, transform.rotation);
            pickHitCount++;
        }
        if (pickHitCount == 5){
            Destroy(other.gameObject);
            pickHitCount = 0;
        }
    }
    void Start(){
        pickSound = GetComponent<AudioSource>();
    }
}
