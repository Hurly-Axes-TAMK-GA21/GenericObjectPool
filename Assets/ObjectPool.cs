using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    public static ObjectPool<T> instance;

    public T objectToPool;
    public int amountToPool;
    private List<T> pooledObjects;

    private void Awake()
    {
        instance = this;
        // Free list is used by free objects
        pooledObjects = new List<T>(amountToPool);
    }

    private void Start()
    {
        // Instantiate objects and disable
        for (int i = 0; i < amountToPool; i++)
        {
            // Instantiate and parent it to transform
            var tmpObject = Instantiate(objectToPool, transform);
            tmpObject.gameObject.SetActive(false);
            pooledObjects.Add(tmpObject);
        }
    }

    public virtual void Deactivate(T objectToDeActivate)
    {
        objectToDeActivate.gameObject.SetActive(false);
    }

    public virtual void Activate(T objectToActivate)
    {
        objectToActivate.gameObject.SetActive(true);
    }

    private void IncreasePoolSize()
    {
        // If there is not disabled objects in pool == If there is not free objects in pool
    }

    public T GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // If there is disabled objects in pool
            if (!pooledObjects[i].gameObject.activeInHierarchy)
            {
                return (pooledObjects[i]);
            }
            else
            {
                IncreasePoolSize();
            }
        }

        return null;
    }
}