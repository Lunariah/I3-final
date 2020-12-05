using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Level")]
public class LevelData : ScriptableObject
{
    
    [Tooltip("Leave blank to reuse the current scene")]
    public string scene = "";
    [Range(0,100)]
    public int Speed;
    public EnemyPool Objective;
    public EnemyPool Spawns;
    public bool infinite;

}

[System.Serializable]
public class EnemyPool
{
    private int boss = 0;
    public int any = 0;
    public int anyGenerator = 0;
    public int straight = 0;
    public int zigzag = 0;
    public int sinus = 0;
    public int staticGenerator = 0;
    public int horizontalGenerator = 0;
    public int straightBomber = 0;

    public void Add(EnemyType item)
    {
        switch (item)
        {
            case EnemyType.Boss:
                boss++;
                break;
            case EnemyType.Straight:
                straight++;
                break;
            case EnemyType.Zigzag:
                zigzag++;
                break;
            case EnemyType.Sinus:
                sinus++;
                break;
            case EnemyType.StaticGenerator:
                staticGenerator++;
                anyGenerator++;
                break;
            case EnemyType.HorizontalGenerator:
                horizontalGenerator++;
                anyGenerator++;
                break;
            case EnemyType.StraightBomber:
                straightBomber++;
                anyGenerator++;
                break;
        }
        any++;
    }

    public bool Equals(EnemyPool other)
    {
        if ((any == other.any)
            && (anyGenerator == other.anyGenerator)
            && (straight == other.straight)
            && (zigzag == other.zigzag)
            && (sinus == other.sinus)
            && (staticGenerator == other.staticGenerator)
            && (horizontalGenerator == other.staticGenerator)
            && (straightBomber == other.straightBomber))
            return true;
        else return false;
    }
}