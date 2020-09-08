using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autohide : MonoBehaviour
{
    private Color alpha;

    void Start()
    {   
        alpha = new Color (0,0,0,255);

        foreach (Transform child in transform)
        {
            child.GetComponent<SpriteRenderer>().color -= alpha;
        }
    }
}