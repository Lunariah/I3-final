using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public SpawnWeights weights;
    public GameObject Straight;
    public GameObject Zigzag;
    public GameObject Sinus;
    public GameObject StaticGenerator;
    public GameObject HorizontalGenerator;
    public GameObject StraightBomber;

    private List<Transform> spawners;

    private void Awake()
    {
        if (transform.childCount == 0) {
            Debug.LogError("Spawn Manager has no child to use as spawn points");
            return;
        }
        spawners = new List<Transform>();
        for(int i = 0; i < transform.childCount; i++)
        {
            spawners.Add(transform.GetChild(i));
        }
    }
    public void Spawn(EnemyType enemyToSpawn)
    {
        /*
        GameObject newEnemy = enemyToSpawn switch
        {
            EnemyType.Straight => Straight,
            EnemyType.Zigzag => Zigzag,
            EnemyType.Sinus => Sinus,
            EnemyType.StaticGenerator => StaticGenerator,
            EnemyType.HorizontalGenerator => HorizontalGenerator,
            EnemyType.StraightBomber => StraightBomber,
            _ => null,
        };
        // *Cries in C# 7.1*
        */

        GameObject newEnemy;
        switch(enemyToSpawn)
        {
            case EnemyType.Straight:
                newEnemy = Straight;
                break;
            case EnemyType.Zigzag:
                newEnemy = Zigzag;
                break;
            case EnemyType.Sinus:
                newEnemy = Sinus;
                break;
            case EnemyType.StaticGenerator:
                newEnemy = StaticGenerator;
                break;
            case EnemyType.HorizontalGenerator:
                newEnemy = HorizontalGenerator;
                break;
            case EnemyType.StraightBomber:
                newEnemy = HorizontalGenerator;
                break;
            default:
                newEnemy = null;
                break;
        };
        
        if (newEnemy == null) {
            Debug.LogError("Enemy type unknown to SpawnManager");
        }
        else {
            Instantiate(newEnemy, spawners[Random.Range(0, spawners.Count)].position, Quaternion.identity);
        }
    }

    public void Spawn()
    {
        if (weights == null) {
            Debug.LogError("No Spawn Weights object assigned to Spawn Manager");
            return;
        }

        Spawn(weights.randomSelect());
    }
}