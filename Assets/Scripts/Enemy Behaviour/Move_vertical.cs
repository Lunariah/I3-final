using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_vertical : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        transform.position += new Vector3(0, -speed * Time.deltaTime);
    }
}