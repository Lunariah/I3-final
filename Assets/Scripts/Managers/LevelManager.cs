using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public String levelName = "";
    public float timer = 5f;
    [Range(1,5)] [Tooltip("Seconds between each spawn")] public float spawnDelay = 2;

    [Tooltip("Defaults to Light")] protected Animator lightAnim;
    protected GameManager game;
    protected SpawnManager spawner;
    protected TextMeshProUGUI timerUI;
    protected float secondsUntilNextSpawn = 0;
    protected bool timeTicking = true;
    protected float timerOnLastUpdate;
    protected int minutes, seconds;



    protected virtual void Start()
    {
        game = GameManager.instance;
        if (game == null) { Debug.LogError("Game won’t let us talk to the manager"); enabled = false;  return; } ;

        spawner = GameObject.FindObjectOfType<SpawnManager>();
        if (spawner == null) { Debug.LogError("Can’t find Spawn Manager");}

        timerUI = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        if (timerUI == null) { Debug.LogError("Can’t find ’Timer’ object with TextMeshProUGUI"); }

        lightAnim = GameObject.Find("Light").GetComponent<Animator>();
        if (lightAnim == null) { Debug.LogError("Can’t find ’Light’ object with animator");}

        timerOnLastUpdate = timer + 61;
    }

    protected void TriggerSpawners()
    {
        if (spawner != null)
        {
            secondsUntilNextSpawn -= Time.deltaTime;
            if (secondsUntilNextSpawn <= 0)
            {
                spawner.Spawn();
                secondsUntilNextSpawn = spawnDelay;
            }
        }
    }

    protected virtual void Update()
    {
        
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