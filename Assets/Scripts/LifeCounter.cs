using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    public int initialLives = 5;
    private List<Image> icons;
    private int _remaining;
    public int Remaining {
        get { return _remaining; }
        set {
            _remaining = value;
            for (int i = 0; i < icons.Count; i++)
            {
                icons[i].enabled = (_remaining > i);
            }
        }
    }

    void Start()
    {
        icons = new List<Image>();
        Image current;
        for(int i = 0; i < transform.childCount; i++)
        {
            current = transform.GetChild(i).GetComponent<Image>();

            if (current == null) {
                Debug.Log("Life Counter has a child without an Image component: " + transform.GetChild(i).name);
            }
            else {
                icons.Add(current);
            }
        }
        Remaining = initialLives;
    }

    void Update()
    {
        
    }
}
