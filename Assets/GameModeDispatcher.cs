using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeDispatcher : MonoBehaviour
{
    private GameManager game;

    void Awake()
    {
        game = GameObject.FindObjectOfType<GameManager>();

        if (game == null)
            Debug.LogError("GameModeDispatcher: Can’t find Game Manager");
        else if (game.endless)
            SceneManager.LoadSceneAsync("Endless");
        else
            SceneManager.LoadSceneAsync("Arcade_1");
    }
}