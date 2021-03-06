﻿using System.Collections;
using UnityEngine;

namespace TowerDefence
{
    /// <summary>
    /// Test enemy class for testing object pool.
    /// </summary>
    public class Enemy : EnemyBase
    {
        private float aliveTime = 5f;

        private void OnEnable()
        {
            StartCoroutine(DeathTimer(aliveTime));
        }

        IEnumerator DeathTimer(float timeToLive)
        {
            yield return new WaitForSeconds(timeToLive);
            DestroyEnemy();
        }

        void Update()
        {
            transform.Translate(0, 0, 1 * 3f * Time.deltaTime);
        }

        /// <summary>
        /// Override the base DestroyEnemy method since we are using object pool for this.
        /// </summary>
        public override void DestroyEnemy()
        {
            EnemyPool.instance.AddObjectToPool(this);
        }

        private void OnTriggerEnter(Collider other)
        {   // Take damage for the amount.
            TakeDamage(50);
        }
    }
}
