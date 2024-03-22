using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroid : MonoBehaviour
{
    public PickAxeSpawnItem pick;
    

    void Update()
    {
        if (pick.pickHitCount == 5){
        Destroy(gameObject);
        }
    }
}
