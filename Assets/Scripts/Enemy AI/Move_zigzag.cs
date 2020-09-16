using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_zigzag : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    [Tooltip("Radiants")]
    [Range(-1.5f, 1.5f)]
    [SerializeField] private float angle = 0.7853981633974483f;

    [SerializeField] private float range = 1;

    private float horizontalSpeed;
    private float xOrigin;
    private float minX, maxX;

    private void Start()
    {
        xOrigin = transform.position.x;
        minX = xOrigin - range;
        maxX = xOrigin + range;
        horizontalSpeed = Mathf.Tan(angle) * speed;
    }

    private void Update()
    {
       // if we’re within range radius
       if (transform.position.x >= minX && transform.position.x <= maxX)
        {
            // Move
            transform.position += new Vector3(horizontalSpeed * Time.deltaTime, -speed * Time.deltaTime);
        }
       else
        {
            // Go back to the limit and change direction
            transform.position = new Vector3(xOrigin + range * Mathf.Sign(horizontalSpeed), transform.position.y, transform.position.z);
            horizontalSpeed = -horizontalSpeed;
        }
    }
}


/*
 * if (range - trans.position.x) > 0
 * if (-range - trans.position.x) > 0
 * 
 * 
 * 
 * if ((trans.position.x - xOrigin) - (xOrigin + range) < 0) move
 * if ((trans.position.x - xOrigin) + (xOrigin + range) > 0) move
 * 
 * if (trans.position.x + range -xOrigin *2)
 * if (trans.position.x + range)
 */
  