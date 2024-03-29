using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienHit : MonoBehaviour
{
    public int hitPoints = 100;

    public AudioSource hitSound;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            hitPoints -= 10;
            if (hitPoints > 0) 
            {
                hitSound.Play();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
