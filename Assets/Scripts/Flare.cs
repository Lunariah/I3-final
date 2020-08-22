using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Flare : MonoBehaviour
{
    public float lifetime = 2f;

    private Queue<SpriteRenderer> list;
    private Color alpha;
    private bool destroyed = false;

    private void Start()
    {
        list = new Queue<SpriteRenderer>();
        alpha = new Color(0, 0, 0, 255);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<SpriteRenderer>().color += alpha;
            list.Enqueue(collision.GetComponent<SpriteRenderer>());
        }
    }

    private void Update()
    {
        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;
        }
        else 
        {
            foreach (SpriteRenderer i in list)
            {
                if (i != null) { i.color -= alpha; }
            }
            Destroy(gameObject);
        }
    }
}