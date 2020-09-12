using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_horizontal : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float range;

    private float xOrigin, minX, maxX;

    private void Start()
    {
        xOrigin = transform.position.x;
        minX = xOrigin - range;
        maxX = xOrigin + range;
    }
    private void Update()
    {
        if (transform.position.x >= minX && transform.position.x <= maxX)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0);
        }
        else
        {
            transform.position = new Vector3(xOrigin + range * Mathf.Sign(speed), transform.position.y);
            speed = -speed;
        }
    }
}