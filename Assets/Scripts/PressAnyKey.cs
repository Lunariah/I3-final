using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressAnyKey : MonoBehaviour
{
    private GameManager game;

    void Start()
    {
        game = GameObject.FindObjectOfType<GameManager>();
        if (game == null) { Debug.LogError("Can’t find Game Manager."); enabled = false; }
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetButtonDown("Fire1"))
                game.BackToMenu();
            else
            {
                // Display ("press space")
            }
        }
        
    }
}