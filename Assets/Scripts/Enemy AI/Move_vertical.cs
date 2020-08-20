using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_vertical : MonoBehaviour
{
    public float speed;


    void Update()
    {
        GetComponent<Transform>().position += new Vector3(0, -speed * Time.deltaTime);
    }
}