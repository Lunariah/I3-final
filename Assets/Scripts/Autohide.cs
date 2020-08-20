using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autohide : MonoBehaviour
{
    private int childCount;
    private Color alpha;

    void Start()
    {   
        alpha = new Color (0,0,0,255);
        childCount = GetComponent<Transform>().childCount;
        for (int i = 0; i < childCount; i++)
        {
            GetComponent<Transform>().GetChild(i).GetComponent<SpriteRenderer>().color -= alpha;
        }
    }
}
