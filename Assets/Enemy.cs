using System.Collections;
using UnityEngine;

namespace TowerDefence
{
    /// <summary>
    /// Test enemy class for testing object pool.
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        private float aliveTime = 5f;

        private void OnEnable()
        {
            StartCoroutine(DeathTimer(aliveTime));
        }

        IEnumerator DeathTimer(float timeToLive)
        {
            yield return new WaitForSeconds(timeToLive);

            Die();
        }

        /// <summary>
        /// Puts this GameObject back to object pool.
        /// </summary>
        private void Die()
        {
            EnemyPool.instance.AddObjectToPool(this);
        }

        void Update()
        {
            transform.Translate(0, 0, 1 * 3f * Time.deltaTime);
        }
    }
}
