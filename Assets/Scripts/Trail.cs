using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// USE LINE RENDERER INSTEAD

public class Trail : MonoBehaviour
{
    public GameObject sprite;
    public int length = 60;

    private Queue<GameObject> tail;
    private Transform trans;

    void Start()
    {
        trans = GetComponent<Transform>();

        tail = new Queue<GameObject>(length);
        
        for (int i=0; i < length; i++)
        {
            tail.Enqueue(null);
        }
       
    }

    void Update()
    {
        Destroy(tail.Dequeue());
        tail.Enqueue(Instantiate(sprite, trans.position, Quaternion.identity));
    }

    private void OnDestroy()
    {
       for (int i=0; i < length; i++)
        {
            Destroy(tail.Dequeue());
        }
    }
}
