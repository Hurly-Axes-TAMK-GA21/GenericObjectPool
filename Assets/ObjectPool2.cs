using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool2<T> : MonoBehaviour where T : MonoBehaviour
{
    // Singleton instance
    public static ObjectPool2<T> instance { get; private set; }

    // Set which object should be pooled into this pool
    [SerializeField, Tooltip("Set the object to be pooled")]
    private T objectToPool;

    // Set how many objects should be put into the initial queue
    [SerializeField, Tooltip("Set the initial pool size amount")]
    private int amountToPool;

    // Set how many additional objects will be created for the queue if the initial amount is exceeded
    [SerializeField, Tooltip("Set by how much the queue will be increased if pool runs empty")]
    private int poolIncreaseAmount;

    // The queue where the objects will be placed and pulled from by the pool
    private Queue<T> poolQueue = new Queue<T>();

    private void Awake()
    {
        instance = this;

        // Add the starting amount of objects to the pool
        AddObjectsToQueue(amountToPool); 
    }

    public virtual void ReturnToPool(T objectToPool)
    {
        objectToPool.gameObject.SetActive(false);
        poolQueue.Enqueue(objectToPool);

    }

    public virtual void Activate(T objectToActivate)
    {
        objectToActivate.gameObject.SetActive(true);
    }

    private void AddObjectsToQueue(int amount)
    {
        // Add the given amount of the objects into the pool queue and set them inactive
        for (int i = 0; i < amount; i++)
        {
            var newObject = Instantiate(objectToPool, transform);
            newObject.gameObject.SetActive(false);
            poolQueue.Enqueue(newObject);
        }
    }

    public T GetPooledObject()
    {
        if (poolQueue.Count == 0)
        {
            AddObjectsToQueue(poolIncreaseAmount);
        }

        var objectFromPool = poolQueue.Dequeue();

        Activate(objectFromPool);

        return objectFromPool;
    }
}