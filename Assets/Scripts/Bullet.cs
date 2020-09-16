using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject smallFlare;
    [SerializeField] private GameObject bigFlare;
    [SerializeField] private float detonateAtVelocity = 0.2f;

    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Detonate(GameObject flareType)
    {
        Destroy(gameObject);
        Instantiate(flareType, body.position, Quaternion.identity);
        Debug.Log("Detonated");
    }

    void FixedUpdate()
    {
        if (body.velocity.y <= detonateAtVelocity)
        {
            Detonate(smallFlare);
            Debug.Log("Whiffed");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Detonate(bigFlare);
            Debug.Log("Invader destroyed");
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Destroyed");
    }
}