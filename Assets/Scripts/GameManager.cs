using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance = null;

    [SerializeField] private LevelData[] levels;
    private int levelIndex = 0;
    public LevelData CurrentLevel
    {
        get { return levels[levelIndex]; }
    }
    
    public void GoToNextLevel()
    {
        levelIndex++;
        if (levelIndex >= levels.Length)
        {
            // End game
        }
        else if (levels[levelIndex].scene != null) 
        { 
            SceneManager.LoadScene(levels[levelIndex].scene); 
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else { Destroy(gameObject); }
    }
}