using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPointOne, spawnPointTwo;

    void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPointOne.position, spawnPointOne.rotation);
        Instantiate(enemyPrefab, spawnPointTwo.position, spawnPointTwo.rotation);

    }
}
