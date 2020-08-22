using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public GameObject smallFlare;
    public GameObject bigFlare;

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
            Detonate(smallFlare);
        }
    }

    void Detonate(GameObject flareType)
    {
        Destroy(gameObject);
        Instantiate(flareType, body.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Detonate(bigFlare);
            Debug.Log("Invader destroyed");
        }
    }
}
