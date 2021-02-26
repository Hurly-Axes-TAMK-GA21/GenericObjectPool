using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    /// <summary>
    /// Generic Object pool base class which will be used to create sub object pools.
    /// </summary>
    /// <typeparam name="T">All subclasses must derive from MonoBehaviour</typeparam>
    public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        /// We use one pool for one type of objects. We will use instance of each pool to access it easily.
        /// </summary>
        public static ObjectPool<T> instance { get; private set; }

        /// <summary>
        /// Set which object should be pooled into this pool
        /// </summary>
        [SerializeField, Tooltip("Set the object to be pooled")]
        private T objectToPool;

        /// <summary>
        /// Set how many objects should be put into the initial queue
        /// </summary>
        [SerializeField, Tooltip("Set the initial pool size amount")]
        private int amountToPool;

        /// <summary>
        /// Set how many additional objects will be created for the queue if the initial amount is exceeded
        /// </summary>
        [SerializeField, Tooltip("Set by how much the queue will be increased if pool runs empty")]
        private int poolIncreaseAmount;

        /// <summary>
        /// The queue where the objects will be placed and pulled from by the pool
        /// </summary>
        private Queue<T> inActiveObjectsQueue = new Queue<T>();

        private void Awake()
        {
            instance = this;

            // Add the starting amount of objects to the pool
            AddObjectsToQueue(amountToPool);
        }

        /// <summary>
        /// Sets object Disabled in hierarchy and
        /// Returns selected object to the end of pool Queue.
        /// Virtual method that can be overwritten with custom features in the sub pool class.
        /// </summary>
        /// <param name="objectToPool">Object to be returned to the pool</param>
        public virtual void AddObjectToPool(T objectToPool)
        {
            objectToPool.gameObject.SetActive(false);

            inActiveObjectsQueue.Enqueue(objectToPool);
        }

        /// <summary>
        /// Activates the object in hierarchy.
        /// Virtual method that can be overwritten with custom features in the sub pool class.
        /// </summary>
        /// <param name="objectToActivate">Object to be activated in the hierarchy</param>
        public virtual void Activate(T objectToActivate)
        {
            objectToActivate.gameObject.SetActive(true);
        }

        /// <summary>
        /// Add given amount of objects to Queue pool.
        /// We parent objects to this object pool GameObject, so it doesn't fill up scenes hierarchy.
        /// </summary>
        /// <param name="amount">Amount of objects to be added to the pool</param>
        private void AddObjectsToQueue(int amount)
        {
            // Add the given amount of the objects into the pool queue.
            for (int i = 0; i < amount; i++)
            {
                var newObject = Instantiate(objectToPool, transform);

                AddObjectToPool(newObject);
            }
        }

        /// <summary>
        /// Checks if there are inActive objects available.
        /// If there are inActive objects,
        /// it will add declared amount so there are always objects available.
        /// Removes and returns the object at the beginning of the Queue.
        /// </summary>
        /// <returns>Object from object pool</returns>
        public T GetPooledObject()
        {
            if (inActiveObjectsQueue.Count == 0)
            {
                AddObjectsToQueue(poolIncreaseAmount);
            }

            var objectFromPool = inActiveObjectsQueue.Dequeue();

            return objectFromPool;
        }
    }
}
