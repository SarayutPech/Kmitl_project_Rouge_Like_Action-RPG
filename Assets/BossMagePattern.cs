using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMagePattern : EnemyPattern
{

    private void Start()
    {
        enemyAi = GetComponent<EnemyAi>();
    }

    public override void todo()
    {
        if (!shouldAttack())
        {
            enemyAi.PathFollow(enemyAi.speed);
            stage = "normal stage";
        }
        else
        {
            randomAction();
        }
    }
    public void randomAction()
    {

        if (thinkingTime_remaining <= 0)
            rand = Random.Range(0, 4);

        if (rand == 0)
            attack1();
        else if (rand == 1)
            attack2();
        else if (rand == 2)
            attack3();

        Debug.Log(rand);
    }

    public void attack1()
    {
        animator.SetTrigger("attack1");
    }

    public void attack2()
    {
        animator.SetTrigger("attack2");
    }

    public void attack3()
    {
        animator.SetTrigger("attack3");
    }

    public void warp()
    {
        animator.SetTrigger("warp");
    }

}
