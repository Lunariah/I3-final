using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// TO DELETE

[RequireComponent(typeof(Collider2D))]
public class VisibilityZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<SpriteRenderer>().color += new Color(0,0,0,255);
        }
    }
}