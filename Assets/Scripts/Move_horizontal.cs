using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_horizontal : MonoBehaviour
{
    public float speed;
    public float range;

    private float xOrigin, minX, maxX;
    private Transform trans;

    private void Start()
    {
        trans = GetComponent<Transform>();
        xOrigin = trans.position.x;
        minX = xOrigin - range;
        maxX = xOrigin + range;
    }
    private void Update()
    {
        if (trans.position.x >= minX && trans.position.x <= maxX)
        {
            trans.position += new Vector3(speed * Time.deltaTime, 0);
        }
        else
        {
            trans.position = new Vector3(xOrigin + range * Mathf.Sign(speed), trans.position.y);
            speed = -speed;
        }
    }
}