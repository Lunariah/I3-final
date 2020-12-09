using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class LevelManager : MonoBehaviour
{
//    public LevelData levelData;
//    private EnemyPool score;
    public float timer = 5f;
    [Range(1,5)] public float levelSpeed = 2;

    private float secondsUntilNextSpawn = 0;
    private GameManager game;
    private float timerOnLastUpdate;
    private int minutes, seconds;
    private TextMeshProUGUI timerUI;
    private SpawnManager spawner;



    private void Awake()
    {
        game = GameManager.instance;
        if (game == null) { Debug.LogError("Game won’t let us talk to the manager"); enabled = false;  return; } ;

        spawner = GameObject.FindObjectOfType<SpawnManager>();
        if (spawner == null) { Debug.LogError("Can’t find Spawn Manager");}
/*
        levelData = game.CurrentLevel;
        if (levelData == null) { Debug.LogError("Can’t find level data in Game Manager"); enabled = false; return; }

        score = new EnemyPool();
*/
        timerUI = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        timerOnLastUpdate = timer + 61;
    }

    private void Update()
    {
        updateTimer();

        if (timer > 0 && spawner != null)
        {
            secondsUntilNextSpawn -= Time.deltaTime;
            if (secondsUntilNextSpawn <= 0)
            {
                spawner.Spawn();
                secondsUntilNextSpawn = levelSpeed;
            }
        }
    }

    private void updateTimer() // Update the timer if necessary
    {
        if (timerUI == null) {
            Debug.LogError("No Timer object found");
            return;
        }

        if (timerOnLastUpdate >= timer + 60)  // If it’s been at least a second since the last time the timer was updated
        {
            timerOnLastUpdate = timer;
            if (timer > 0) {
                timer -= Time.deltaTime;
                minutes = (int)(timer / 60);
                seconds = (int)(timer % 60);
                timerUI.SetText(String.Format("{0:00}:{1:00}", minutes, seconds));
            }
            
            else { // When the timer reaches 0, it will no longer count down and thus the first condition will always be false
                timer = 0;
                timerUI.SetText("0:00");
            }
        }
    }
    /*
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
*/
}