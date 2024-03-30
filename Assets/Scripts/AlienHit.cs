using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlienHit : MonoBehaviour
{
    public int hitPoints, moveSpeed, shotPower;

    public AudioSource hitSound;

    public float sightRange, attackRange, shotTimer, destroyTimer;

    public Transform player, shootPoint;

    private bool _playerInSight, _playerInRange, _alreadyAttacked;

    public LayerMask playerLayer;

    public GameObject enemyBullet;
    
    private void OnCollisionEnter(Collision collision)
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
    
    private void Awake()
    {
        player = GameObject.Find("XR Origin").transform;
    }

    private void Update()
    {
        _playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        _playerInRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (_playerInSight && !_playerInRange) Chase();
        if (_playerInSight && _playerInRange) Attack();
    }

    private void Chase()
    {
        Vector3 targetPosition = new Vector3( player.position.x, transform.position.y, player.position.z );
        transform.LookAt(targetPosition);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void Attack()
    {
        Vector3 targetPosition = new Vector3( player.position.x, transform.position.y, player.position.z );
        transform.LookAt(targetPosition);

        if (!_alreadyAttacked)
        {
            var bullet = Instantiate(enemyBullet, shootPoint.transform.position, shootPoint.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(shootPoint.transform.up * shotPower);
            
            Destroy(bullet, destroyTimer);

            _alreadyAttacked = true;
            Invoke(nameof(ResetAttack), shotTimer);
        }
    }

    private void ResetAttack()
    {
        _alreadyAttacked = false;
    }
}
