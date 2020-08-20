using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public GameObject flare;

    private Rigidbody2D body;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Debug.Log(body.velocity.y);
        if (body.velocity.y <= 0.2f)
        {
            Detonate();
        }
    }

    void Detonate()
    {
        Instantiate(flare, body.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Detonate();
            Destroy(collision.gameObject);
        }
    }
}
