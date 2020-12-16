using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeManager : LevelManager
{
    private bool timeTicking = true;

    override protected void Start()
    {
        base.Start();
        lightAnim.SetTrigger("Level cleared");
    }
    
    override protected void Update()
    {
        base.Update();

        if (timeTicking) 
        {
            updateTimer();

            // Spawn enemies
            spawnersUpdate();
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {

                StartCoroutine(game.GoToNextLevel(2));

                this.enabled = false;
            }
        }
    }

    private void updateTimer() // Update the timer if necessary
    {
        // if (!timeTicking) 
        //     return;

        timer -= Time.deltaTime;
        
        if (timerOnLastUpdate >= timer + 1)  // If it’s been at least a second since the last time the timer was updated
        {
            timerOnLastUpdate = timer;
            if (timer > 0) {
                minutes = (int)(timer / 60);
                seconds = (int)(timer % 60);
                timerUI.SetText(String.Format("{0:00}:{1:00}", minutes, seconds));
            }
            
            else { 
                timer = 0;
                timerUI.SetText("00:00");
                lightAnim.SetTrigger("Time up");
                timeTicking = false;
            }
        }
    }
}
