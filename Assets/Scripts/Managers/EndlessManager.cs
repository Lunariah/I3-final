using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessManager : LevelManager
{
    override protected void Start()
    {
        base.Start();
        timerUI.text = "" + game.score;
    }

    override protected void Update()
    {
        base.Update();

        spawnersUpdate();
    }

    public override void EnemyDestroyed(EnemyType enemy)
    {
        base.EnemyDestroyed(enemy);
        timerUI.text = "" + game.score;
    }
}
