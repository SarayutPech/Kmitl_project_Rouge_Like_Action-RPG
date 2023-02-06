using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroPattern : EnemyPattern
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
            rand = Random.Range(0, 5);

        if (rand == 0)
            attack1();
        else if (rand == 1)
            attack2();
        else if (rand == 2)
            attack3();
        else if (rand == 3)
            block();      
        else if (rand == 4)
            roll();
        
        //attack1();

        //roll();
        Debug.Log(rand);
    }

    public void roll()
    {
        animator.SetTrigger("roll");
    }

    public void block()
    {
        animator.SetTrigger("block");
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

    
}
