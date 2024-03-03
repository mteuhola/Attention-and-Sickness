using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeHit : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name + " hit " + collision.gameObject.name);
        Debug.Log(collision.impulse.magnitude * 100);
    }
}
