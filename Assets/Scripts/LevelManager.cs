using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelData levelData;
    private GameManager game;
    private int score;

    void EnemyDestroyed(GameObject destroyed)
    {
        
    }

    private void Awake()
    {
        game = GameManager.instance;
        if (game == null) { Debug.LogError("Game won’t let us talk to the manager"); enabled = false;  return; } ;

        levelData = game.CurrentLevel;
        if (levelData == null) { Debug.LogError("Can’t find level data in Game Manager"); enabled = false; return; }
    }

}