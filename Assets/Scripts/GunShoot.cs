using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public GameObject bulletPrefab, shootPointUp, shootPointDown;
    public float shotPower = 250f;
    public float destroyTimer = 6f;
    public int magSize = 3;

    public Material fullMaterial, emptyMaterial;
    public Renderer clipRenderer;
    private int clipMaterialIndex = 3;

    public AudioSource gunSound;
    

    void Start()
    {
        gunSound = GetComponent<AudioSource>();
        clipRenderer = GetComponent<Renderer>();
        Material[] materials = clipRenderer.materials;
        materials[clipMaterialIndex] = fullMaterial;
        clipRenderer.materials = materials;
    }
    
    public void Shoot()
    {
        if (magSize > 0)
        {
            magSize -= 1;
            if(magSize == 0)
            {
                Material[] materials = clipRenderer.materials;
                materials[clipMaterialIndex] = emptyMaterial;
                clipRenderer.materials = materials;
            }

            GameObject upBullet, downBullet;
            upBullet = Instantiate(bulletPrefab, shootPointUp.transform.position, shootPointUp.transform.rotation);
            upBullet.GetComponent<Rigidbody>().AddForce(shootPointUp.transform.up * shotPower);
            upBullet.AddComponent<Bullet>();
            upBullet.GetComponent<Bullet>().gunShoot = this;

            downBullet = Instantiate(bulletPrefab, shootPointDown.transform.position, shootPointDown.transform.rotation);
            downBullet.GetComponent<Rigidbody>().AddForce(shootPointDown.transform.up * shotPower);

            gunSound.Play();

            Destroy(upBullet, destroyTimer);
            Destroy(downBullet, destroyTimer);

        }
    }

    public void BulletDestroyed()
    {
        magSize += 1;
        Material[] materials = clipRenderer.materials;
        materials[clipMaterialIndex] = fullMaterial;
        clipRenderer.materials = materials;

    }
}
