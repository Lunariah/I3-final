using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// USE TRAIL RENDERER INSTEAD

public class Trail : MonoBehaviour
{
    public GameObject sprite;
    public int length = 60;

    private Queue<GameObject> tail;


    void Start()
    {
        Debug.LogError("Using scrapped Trail.cs script");

        /*
        tail = new Queue<GameObject>(length);
        
        for (int i=0; i < length; i++)
        {
            tail.Enqueue(null);
        }
        */
       
    }

    /*
    void Update()
    {
        Destroy(tail.Dequeue());
        tail.Enqueue(Instantiate(sprite, transform.position, Quaternion.identity));
    }

    private void OnDestroy()
    {
       for (int i=0; i < length; i++)
        {
            Destroy(tail.Dequeue());
        }
    }
    */
}
