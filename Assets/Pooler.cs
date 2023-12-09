using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    private Transform[] pooledObjects;
    private int[] poolHistory;

    private void Awake()
    {
        pooledObjects = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            pooledObjects[i] = transform.GetChild(i);
        }

        poolHistory = new int[pooledObjects.Length];
    }

    private int FindInactiveObjectIndex()
    {
        for (int i = 0; i < pooledObjects.Length; i++)
        {
            if (!pooledObjects[i].gameObject.activeSelf)
                return i;
        }

        return poolHistory.Last();
    }

    private void UpdateHistory(int newestIndex)
    {
        for (int i = 0; i < poolHistory.Length - 1; i++)
        {
            poolHistory[i + 1] = poolHistory[i];
        }

        poolHistory[0] = newestIndex;
    }

    public Transform ActivateNewObject()
    {
        int index = FindInactiveObjectIndex();
        
        UpdateHistory(index);

        pooledObjects[index].gameObject.SetActive(true);
        return pooledObjects[index];
    }

    public void DeactivateObject(Transform deactivatedObject)
    {
        foreach (var pooledObject in pooledObjects)
        {
            if (deactivatedObject == pooledObject)
            {
                pooledObject.gameObject.SetActive(false);
                return;
            }
        }
    }
}