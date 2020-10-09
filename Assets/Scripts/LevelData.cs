using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Level")]
public class LevelData : ScriptableObject
{
    [System.Serializable]
    public class EnemyPool
    {
        private int boss;
        public int any;
        public int anyGenerator;
        public int zigzag;
        public int sinus;
        public int staticGenerator;
        public int horizontalGenerator;
        public int straightBomber;
        public bool infinite;
    }
    [Tooltip("Leave blank to reuse the current scene")]
    public string scene = "";
    public EnemyPool Objective;
    public EnemyPool Spawns;

}
