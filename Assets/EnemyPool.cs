using UnityEngine;

namespace TowerDefence
{
    /// <summary>
    /// Class that extends the Generic Object Pool Class.
    /// You must define type of Object Pool you want to make.
    /// </summary>
    public class EnemyPool : ObjectPool<Enemy>
    {

        /// <summary>
        /// Sets enemy Disabled in hierarchy and
        /// Returns selected enemy to the end of pool Queue.
        /// Reset transforms position before it's added to pool and also reset the health of the unit.
        /// </summary>
        /// <param name="objectToPool">Enemy to be returned to the pool</param>
        public override void AddObjectToPool(Enemy objectToPool)
        {
            objectToPool.gameObject.transform.position = new Vector3(0, 0, 0);
            objectToPool.ResetHealth();
            base.AddObjectToPool(objectToPool);
        }
    }
}
