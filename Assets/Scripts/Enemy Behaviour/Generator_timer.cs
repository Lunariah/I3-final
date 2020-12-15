using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_timer : Generator
{
    [SerializeField] private float spawnRate;

    private float spawnTimer = 0;

    private void Update()
    {
        if (spawnTimer >= spawnRate)
        {
            Spawn();
            spawnTimer = 0;
        }
        else
        {
            spawnTimer += Time.deltaTime;
        }
    }
}