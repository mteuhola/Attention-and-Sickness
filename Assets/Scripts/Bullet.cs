using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GunShoot gunShoot;

    void OnDestroy()
    {
        if (gunShoot != null)
        {
            gunShoot.BulletDestroyed(); // Notify Gun script that a bullet is destroyed
        }
    }
}
