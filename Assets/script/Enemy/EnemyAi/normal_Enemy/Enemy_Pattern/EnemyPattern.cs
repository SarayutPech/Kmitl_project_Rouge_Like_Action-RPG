using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyPattern : MonoBehaviour
{
    public EnemyAi enemyAi;
    [Header("Stage")]
    public string stage;
    public int rand = 0;

    [Header("Status")]

    [Header("Animation")]
    public Animator animator;
    public bool die = false;

    [Header("Pattern Script")]
    [SerializeField] private float thinkingTime_fixed = 5;
    public float thinkingTime_remaining = 0;

    private void Start()
    {
        //Thinking times
        thinkingTime_remaining = thinkingTime_fixed;
        enemyAi = GetComponent<EnemyAi>();
    }

    private void FixedUpdate()
    {

        enemyStage();
        if (enemyAi.TargetInDistance() && enemyAi.followEnable)
        {
            // What your enemy can do doo doo dooo do
            todo();
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", false);
        }

        if (die)
            enemyAi.enemydie();
    }

    public void enemyStage()
    {

        if (thinkingTime_remaining >= thinkingTime_fixed)
            thinkingTime_remaining = 0;
        else
            thinkingTime_remaining += Time.deltaTime;
    }
    public void idle()
    {
        animator.SetBool("isRunning", false);
    }

    public abstract void todo();
}
