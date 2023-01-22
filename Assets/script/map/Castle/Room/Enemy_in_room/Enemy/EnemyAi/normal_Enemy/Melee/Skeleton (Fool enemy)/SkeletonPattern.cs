using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonPattern : EnemyPattern
{
    

    public void attack()
    {
        animator.SetTrigger("attack");
    }

    public override void todo()
    {
        if (!shouldAttack())
        {
            enemyAi.PathFollow(enemyAi.speed);
        }
        else
            attack();
    }
}
