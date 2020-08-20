using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_zigzag : MonoBehaviour
{
    [Tooltip("Units / second")]
    public float speed = 1;

    [Range(-1.5f, 1.5f)]
    [Tooltip("Radiants")]
    public float angle = 0.7853981633974483f;

    public float range = 1;

    public float horizontalSpeed { get; private set; }
    private float xOrigin;
    private float minX, maxX;
    private Transform trans;

    private void Start()
    {
        trans = GetComponent<Transform>();

        xOrigin = trans.position.x;
        minX = xOrigin - range;
        maxX = xOrigin + range;
        horizontalSpeed = Mathf.Tan(angle) * speed;
    }

    private void Update()
    {
       // if we’re within range radius
       if (trans.position.x >= minX && trans.position.x <= maxX)
        {
            // Move
            trans.position += new Vector3(horizontalSpeed * Time.deltaTime, -speed * Time.deltaTime);
        }
       else
        {
            // Go back to the limit and change direction
            trans.position = new Vector3(xOrigin + range * Mathf.Sign(horizontalSpeed), trans.position.y);
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
  