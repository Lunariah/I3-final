using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_timer : MonoBehaviour
{
	public GameObject spawn;
    public float spawnRate;

    private float spawnTimer = 0;

    private void Update()
    {
        if (spawnTimer >= spawnRate)
        {
            Instantiate(spawn, GetComponent<Transform>().position, Quaternion.identity);
            spawnTimer = 0;
        }
        else
        {
            spawnTimer += Time.deltaTime;
        }
    }
}