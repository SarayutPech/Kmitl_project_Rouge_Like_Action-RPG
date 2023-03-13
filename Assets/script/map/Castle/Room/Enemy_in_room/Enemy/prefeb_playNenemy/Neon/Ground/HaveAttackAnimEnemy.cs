using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveAttackAnimEnemy : EnemyPattern
{
    public override void todo()
    {
        if (!shouldAttack())
        {
            enemyAi.PathFollow(enemyAi.speed);
        }
        else
            attack();
    }

    public void attack()
    {
        animator.SetTrigger("attack");
    }
}
