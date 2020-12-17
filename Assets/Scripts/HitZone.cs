using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitZone : MonoBehaviour
{
    public LifeCounter counter;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            if(--counter.Remaining <= 0)
                GameManager.instance.GameOver();
        }
    }
}