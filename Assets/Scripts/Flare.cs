using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


[RequireComponent(typeof(Light2D))]
public class Flare : MonoBehaviour
{
    [Tooltip("How long the flare will stay on screen")]
    public float lifetime = 2f;
    [Tooltip("How long the flare will hang at max size")]
    public float hangtime = 0.5f;
    public float outerRadius = 2f;
    [Range(0f,1f)]
    public float innerRadius = 0.5f;

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
            light2D.pointLightInnerRadius = speed * innerRadius * Time.deltaTime;

            if (elapsed >= lifetime) { Destroy(gameObject); }
        }
        elapsed += Time.deltaTime;
    }
}