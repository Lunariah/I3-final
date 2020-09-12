using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Generator : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnList;
    [SerializeField] private bool random = false;

    private int nextInList = 0;

    protected virtual GameObject Spawn(Vector3 position)
    {
        if (random)
        {
            nextInList = UnityEngine.Random.Range(0, spawnList.Count);
        }
        
        if (nextInList >= spawnList.Count) 
        { 
            nextInList = 0; 
        }
        
        // Instantiate new object
        try
        {
            return Instantiate(spawnList[nextInList++], position, Quaternion.identity);
        }
        catch (ArgumentOutOfRangeException)
        {
            if (spawnList.Count == 0)
            {
                Debug.LogError("Generator has no prefab in its spawn list.");
            }
            else
            {
                Debug.LogError("Generator.Spawn(): ArgumentOutOfRangeException.");
            }
        }
        enabled = false;
        return null;
    }

    protected GameObject Spawn()
    {
        return Spawn(transform.position);
    }
}