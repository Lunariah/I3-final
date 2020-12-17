using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressAnyKey : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetButtonDown("Fire1"))
                GameManager.instance.BackToMenu();
            else
            {
                // Display ("press space")
            }
        } 
    }
}