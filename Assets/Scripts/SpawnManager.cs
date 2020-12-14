using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public SpawnWeights weights;
    private GameObject Straight;
    private GameObject Zigzag;
    private GameObject Sinus;
    private GameObject StaticGenerator;
    private GameObject HorizontalGenerator;
    private GameObject StraightBomber;

    private List<Transform> spawners;

    private void Start()
    {
        spawners = new List<Transform>();

        if (transform.childCount == 0) {
            Debug.Log("SpawnManager has no children to use as spawn points. Using own position instead.");
            spawners.Add(transform);
        }
        else for(int i = 0; i < transform.childCount; i++)
        {
            spawners.Add(transform.GetChild(i));
        }

        Straight = Resources.Load<GameObject>("Enemy type 1 (Straight)");
        Zigzag = Resources.Load<GameObject>("Enemy type 2 (Zigzag)");
        Sinus = Resources.Load<GameObject>("Enemy type 3 (Sin)");
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