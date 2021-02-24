using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool currentlySpawning = false;

    private void Update()
    {
        if (!currentlySpawning)
        {
            StartCoroutine(SpawnCoroutine());
            currentlySpawning = true;
        }
    }

    IEnumerator SpawnCoroutine()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(.2f);
            SpawnEnemy();
        }

        currentlySpawning = false;
    }

    void SpawnEnemy()
    {
        if (EnemyPool.SharedInstance.GetPooledObject())
        {
            var enemy = EnemyPool.SharedInstance.GetPooledObject();
            enemy.gameObject.transform.position = new Vector3(0, 0, 0);
            enemy.gameObject.SetActive(true);
        }
        else
        {
            print("No pooled objects to spawn...");
        }
    }
}
