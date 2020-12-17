using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [HideInInspector] public static LevelManager instance = null;
    public String levelName = "";
    public float timer = 5f;
    [Range(1,5)] [Tooltip("Seconds between each spawn")] public float spawnDelay = 2;

    [Tooltip("Defaults to Light")] protected Animator lightAnim;
    protected GameManager game;
    protected SpawnManager spawner;
    protected TextMeshProUGUI timerUI;
    protected float secondsUntilNextSpawn = 0;
    protected float timerOnLastUpdate;
    protected int minutes, seconds;

    protected virtual void Awake()
    {
        if (instance == null)
            instance = this;
        else
            { Destroy(gameObject); }
    }

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

        lightAnim.SetTrigger("Level restart");

        timerOnLastUpdate = timer + 61;
    }

    protected void spawnersUpdate()
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

    public virtual void EnemyDestroyed(EnemyType enemy)
    {
        switch (enemy)
        {
            case EnemyType.Straight:
                game.score += 5;
                break;
            case EnemyType.Zigzag:
                game.score += 6;
                break;
            case EnemyType.Sinus:
                game.score += 7;
                break;
            default:
                break;
        }
    }

    protected virtual void Update()
    {
        
    }
}