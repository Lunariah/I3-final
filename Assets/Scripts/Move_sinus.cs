using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_sinus : MonoBehaviour
{
    [Tooltip("Units / second")]
    public float speed;

    [Range(-5f, 5f)]
    [Tooltip("Sinus multiplier")]
    public float mod = 1;

    private Vector3 initialPos;
    private float verticalDistance = 0;

    void Start()
    {
        initialPos = GetComponent<Transform>().position;
    }


    void Update()
    {
        verticalDistance += speed * Time.deltaTime;
        GetComponent<Transform>().position = initialPos + new Vector3(Mathf.Sin(verticalDistance) * mod, -verticalDistance);
    }
}