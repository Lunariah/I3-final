using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        collision.GetComponent<SpriteRenderer>().color -= alpha;
        list.Enqueue(collision.GetComponent<SpriteRenderer>());
    }

    private void Update()
    {
        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;
        }
        else if (!destroyed)
        {
            foreach (SpriteRenderer i in list)
            {
                i.color += alpha;
            }
            Destroy(gameObject);
            destroyed = true;
        }
    }
}
