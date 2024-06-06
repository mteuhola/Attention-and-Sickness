using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxeSpawnItem : MonoBehaviour
{
    public OreCollect oreCollect;
    public GameObject itemPrefab;
    public AudioSource pickSound;
    public Transform spawnPosition;
    public int pickHitCount = 0;
    public float destroyTime = 2f;

  private void OnCollisionEnter(Collision other)
    {
        // Check if the collision is with an asteroid
        if (other.gameObject.tag == "stone")
        {
            pickSound.Play();
            // Spawn the item prefab at the collision point
            var moonStone = Instantiate(itemPrefab, spawnPosition.position, spawnPosition.rotation);
            pickHitCount++;
            Destroy(moonStone, destroyTime);
            oreCollect.oreCount++;
        }
        if (pickHitCount == 5){
            Destroy(other.gameObject);
            pickHitCount = 0;
        }
    }
    private void Start(){
        pickSound = GetComponent<AudioSource>();
    }
}
