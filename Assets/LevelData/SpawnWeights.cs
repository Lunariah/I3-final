using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawn data")]
[System.Serializable]
public class SpawnWeights : ScriptableObject
{
    [Range(0,10)] public float straight = 0;
    [Range(0,10)] public float zigzag = 0;
    [Range(0,10)] public float sinus = 0;
    [Range(0,10)] public float staticGenerator = 0; 
    [Range(0,10)] public float horizontalGenerator = 0; 
    [Range(0,10)] public float straightBomber = 0;

    private float sinusThres;
    private float staticGenThres;
    private float horizontalGenThres;
    private float straightBombThres;
    private float randValue;

    public EnemyType randomSelect()
    {
        sinusThres = straight + zigzag;
        staticGenThres = sinusThres + sinus;
        horizontalGenThres = staticGenThres + staticGenerator;
        straightBombThres = horizontalGenThres + horizontalGenerator;

        randValue = Random.Range(0, straightBombThres + straightBomber);

        if (randValue < straight) {
            return EnemyType.Straight;
        }
        if (randValue < sinusThres) {
            return EnemyType.Zigzag;
        }
        if (randValue < staticGenThres) {
            return EnemyType.Sinus;
        }
        if (randValue < horizontalGenThres) {
            return EnemyType.StaticGenerator;
        }
        if (randValue < straightBombThres) {
            return EnemyType.HorizontalGenerator;
        }
        if (straightBomber > 0) {
            return EnemyType.StraightBomber;
        }
        Debug.LogError("Attempting to select an enemy to spawn from an empty SpawnWeghts object");
        return EnemyType.Straight;
    }
}
