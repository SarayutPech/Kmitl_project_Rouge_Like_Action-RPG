using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntressPattern : EnemyPattern
{
    [SerializeField] private float baseAttackCooldown = 0.4f;
    [SerializeField] private float attackCooldown = 0f;
    public void attack()
    {
        if (attackCooldown <= 0)
        {
            animator.SetTrigger("attack");
            attackCooldown = baseAttackCooldown;
        }
        else
            attackCooldown -= Time.deltaTime;
        
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
