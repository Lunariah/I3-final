using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PressAnyKey : MonoBehaviour
{
    [Tooltip("Seconds before the script becomes active")]
    public float waitTime = 1;
    private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        Debug.Log(text);
        text.enabled = false;
    }

    void Update()
    {
        waitTime -= Time.deltaTime;

        if (Input.anyKeyDown)
        {
            if (Input.GetButtonDown("Fire1") && waitTime <= 0)
                GameManager.instance.BackToMenu();
            else
            {
                text.enabled = true;
            }
        } 
    }
}