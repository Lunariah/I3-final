using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class LevelManager : MonoBehaviour
{
    public LevelData levelData;
    private GameManager game;
    private EnemyPool score;
    public float timer = 5f;
    private int minutes, seconds;
    private TextMeshProUGUI timerUI;


    public void EnemyDestroyed(EnemyType destroyed)
    {
        score.Add(destroyed);

        if (!levelData.infinite
            && (score.any >= levelData.Objective.any)
            && (score.anyGenerator >= levelData.Objective.anyGenerator)
            && (score.straight >= levelData.Objective.straight)
            && (score.zigzag >= levelData.Objective.zigzag)
            && (score.sinus >= levelData.Objective.sinus)
            && (score.staticGenerator >= levelData.Objective.staticGenerator)
            && (score.horizontalGenerator >= levelData.Objective.staticGenerator)
            && (score.straightBomber >= levelData.Objective.straightBomber))
        {
            if (levelData.scene != "")
            {
                SceneManager.LoadScene(levelData.scene);
            }
            else
            {
                Debug.Log("Victory!");
            }
        }
    }

    private void Awake()
    {
        game = GameManager.instance;
        if (game == null) { Debug.LogError("Game won’t let us talk to the manager"); enabled = false;  return; } ;

        levelData = game.CurrentLevel;
        if (levelData == null) { Debug.LogError("Can’t find level data in Game Manager"); enabled = false; return; }

        score = new EnemyPool();

        timerUI = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
            minutes = (int)(timer / 60);
            seconds = (int)(timer % 60);
            timerUI.SetText(String.Format("{0:00}:{1:00}", minutes, seconds));
        }
        
        else if (timer < 0) {
            timer = 0;
            timerUI.SetText("0:00");
        }
    }
}