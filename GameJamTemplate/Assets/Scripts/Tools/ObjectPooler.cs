using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject pooledObjectPrefab;
    [SerializeField] private int pooledBaseAmount = 20;
    [SerializeField] private bool canGrow = true; //Defines if this pool can graw by demand;

    [SerializeField] List<GameObject> pooledObjects; //Serialized to see the size in inspector;

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledBaseAmount; i++)
        {
            NewObjectInPool(pooledObjectPrefab);
        }
    }

    /// <summary>
    /// Returns object from pool. If there no free objects in pool and pool can grow, will create new object instance
    /// </summary>
    /// <returns></returns>
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }

        if (canGrow)
            return NewObjectInPool(pooledObjectPrefab);

        Debug.LogWarning("There are no free objects in pool left");
        return null;
    }
    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    private GameObject NewObjectInPool(GameObject prefab)
    {
        GameObject obj = (GameObject)Instantiate(prefab);
        obj.transform.SetParent(this.gameObject.transform);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
