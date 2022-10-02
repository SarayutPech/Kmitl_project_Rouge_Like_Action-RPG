using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreonPattern : EnemyPattern
{
    [Header("Status")]
    [SerializeField] private float currentAttackCooldown = 0f;
    [SerializeField] private float baseAttackSpeed = 1.5f;
    [SerializeField] private float currentSkillcooldown = 0f;
    [SerializeField] private float baseSkillCooldown = 5f;

    private void Start()
    {
        enemyAi = GetComponent<EnemyAi>();
    }

    public override void todo()
    {
        currentSkillcooldown -= Time.deltaTime;
        currentAttackCooldown -= Time.deltaTime;
        if (thinkingTime_remaining <= 0)
        {
            animator.SetBool("isWalking", false);
            rand = Random.Range(0, 10);
            idle();
        }

        if ( !shouldAttack() ) {
            if (rand >= 0 && rand <= 3)
            {
                walk();
                stage = "walk stage";
            }
            else
            {
                enemyAi.PathFollow(enemyAi.speed);
                stage = "normal stage";
            }
        }else
        {
            attack();
        }
    }
    public void attack()
    {
        if (currentSkillcooldown <= 0f)
        {
            animator.SetTrigger("attack2");
            currentSkillcooldown = baseSkillCooldown;
            return;
        }
        else if(currentAttackCooldown <= 0f)
        {
            animator.SetTrigger("attack");
            currentAttackCooldown = baseAttackSpeed;
        }
    }

    public void walk()
    {
        animator.SetBool("isRunning", false);
        enemyAi.PathFollow(enemyAi.speed / 2, -1, "isWalking");
    }

 
}
