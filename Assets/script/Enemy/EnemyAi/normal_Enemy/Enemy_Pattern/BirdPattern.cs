using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPattern : EnemyPattern
{
    float stop_chase_at = 4;
    public override void todo()
    {

        if (base.thinkingTime_remaining <= 0)
            rand = Random.Range(0, 10);

        if (rand >= 0 && rand <= 3)
        {
            Dash();
            stage = "dash stage";
        }
        else if (rand >= 4 && rand <= 6)
        {
            Focus();
            stage = "focus stage";
        }
        else
        {
            enemyAi.PathFollow(enemyAi.speed);
            stage = "normal stage";
        }
    }

    public void Dash()
    {
        enemyAi.PathFollow(enemyAi.speed * 5);
    }

    public void Focus()
    {
        enemyAi.PathFollow(enemyAi.speed / 3, stop_chase_at );
    }
}
