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
        //Debug.Log("Detonated");
    }

    void FixedUpdate()
    {
        if (body.velocity.y <= detonateAtVelocity)
        {
            Detonate(smallFlare);
            //Debug.Log("Whiffed");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Detonate(bigFlare);
            //Debug.Log("Invader destroyed");

            LevelManager.instance.EnemyDestroyed(Identify(other.gameObject));
        }
    }

    private EnemyType Identify(GameObject other)
    {
        if (other.GetComponent<Move_vertical>() != null)
        {
            return EnemyType.Straight;
        }
        else if (other.GetComponent<Move_zigzag>() != null)
        {
            return EnemyType.Zigzag;
        }
        else if (other.GetComponent<Move_sinus>() != null)
        {
            return EnemyType.Sinus;
        }
        else return EnemyType.Boss;
    }

    private void OnDestroy()
    {
        //Debug.Log("Destroyed");
    }
}