using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

// This definitely could have been an animation

[RequireComponent(typeof(Light2D))]
public class Flare : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f; // Total lifetime
    [SerializeField] private float hangtime = 0.5f; // Time spent at max intensity
    [SerializeField] private float outerRadius = 2f;
    [SerializeField] [Range(0f, 1f)] private float innerRadius = 0.5f;

    private Light2D light2D;
    private float speed;
    private float hangPoint;
    private float elapsed = 0f;

    private void Start()
    {
        light2D = GetComponent<Light2D>();
        hangPoint = lifetime / 2 - hangtime / 2;
        speed = outerRadius / hangPoint;
    }

    private void Update()
    {
        if (elapsed < hangPoint)
        {
            // Increase light radius
            light2D.pointLightOuterRadius += speed * Time.deltaTime;
            light2D.pointLightInnerRadius += speed * innerRadius * Time.deltaTime;
        }
        else if (elapsed > hangPoint + hangtime)
        {
            // Decrease light radius
            light2D.pointLightOuterRadius -= speed * Time.deltaTime;
            light2D.pointLightInnerRadius -= speed * innerRadius * Time.deltaTime;

            if (elapsed >= lifetime) { Destroy(gameObject); }
        }
        elapsed += Time.deltaTime;
    }
}