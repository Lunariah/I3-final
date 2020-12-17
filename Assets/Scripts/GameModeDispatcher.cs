using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeDispatcher : MonoBehaviour
{
    void Awake()
    {
        try 
        {    
            if (GameManager.instance.endless)
                SceneManager.LoadSceneAsync("Endless");
            else
                SceneManager.LoadSceneAsync("Arcade_1");
        }
        catch (NullReferenceException) 
        {
            Debug.LogError("Can’t find Game Manager. Load from Menu scene instead.");
            // Checks if Game Manager exists in Init scene since it’s normally the Level Manager’s job
        }
    }
}