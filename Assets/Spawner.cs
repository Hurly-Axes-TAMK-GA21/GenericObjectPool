using System.Collections;
using UnityEngine;

namespace TowerDefence
{
    public class Spawner : MonoBehaviour
    {
        private bool currentlySpawning = false;
        public float spawnInterval = 3f;

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
                yield return new WaitForSeconds(spawnInterval);
                SpawnEnemy();
            }

            currentlySpawning = false;
        }

        /// <summary>
        /// Gets enemy from enemy pool and activates it.
        /// </summary>
        void SpawnEnemy()
        {
            var enemy = EnemyPool.instance.GetPooledObject();

            // For testing spawns at spawner GameObject's position.
            enemy.transform.position = transform.position;

            if (enemy != null)
            {
                EnemyPool.instance.Activate(enemy);
            }
        }
    }
}
