using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance = null;

    public bool endless;

    [SerializeField] private LevelData[] levels;
    private int levelIndex = 0;
    public LevelData CurrentLevel
    {
        get { return levels[levelIndex]; }
    }
    
    public void StartArcadeMode()
    {
        endless = false;
        SceneManager.LoadScene("Init");
        // Game Mode Dispatcher will load the first arcade scene according to this.endless
    }

    public void StartEndlessMode()
    {
        endless = true;
        SceneManager.LoadScene("Init");
        // Game Mode Dispatcher will load the endless scene according to this.endless
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        Destroy(gameObject); // The Menu scene’s new GameManager has to be used so the button events don’t lose their reference
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public IEnumerator GoToNextLevel(float delay)
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        while (delay > 0) {
            delay -= Time.deltaTime;
            yield return null;
        }

        if (SceneUtility.GetScenePathByBuildIndex(nextScene).Contains("ictory")) 
            Destroy(GameObject.Find("Game Core"));
        
        SceneManager.LoadScene(nextScene);
    }

    public void GameOver()
    {
        Destroy(GameObject.Find("Game Core"));
        SceneManager.LoadScene("Game Over");
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