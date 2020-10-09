using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Move_sinus : MonoBehaviour
{
    [Tooltip("Units / second")]
    [SerializeField] private float speed = 1;

    [Tooltip("Sinus multiplier")]
    [SerializeField] private float mod = 1;

    private Vector3 initialPos;
    private float verticalDistance = 0;

    void Start()
    {
        initialPos = transform.position;
    }


    void Update()
    {
        verticalDistance += speed * Time.deltaTime;
        transform.position = initialPos + new Vector3(Mathf.Sin(verticalDistance/50) * mod, -verticalDistance);
    }
}