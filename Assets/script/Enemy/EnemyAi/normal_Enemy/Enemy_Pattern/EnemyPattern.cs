using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPattern : MonoBehaviour
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
    public EnemyPattern enemyPattern;
    [SerializeField] private float thinkingTime_fixed = 5;
    [SerializeField] private float thinkingTime_remaining = 0;

    private Rigidbody2D rb;
    Transform target;

    private void Start()
    {
        //Thinking times
        thinkingTime_remaining = thinkingTime_fixed;


        target = GameObject.FindGameObjectWithTag("Player").transform;

        rb = GetComponent<Rigidbody2D>();
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

    public void todo()
    {

        if (thinkingTime_remaining <= 0)
            rand = Random.Range(0, 10);

        if (rand >= 0 && rand <= 3)
        {
            
            stage = "";
        }
        else if (rand >= 4 && rand <= 6)
        {
            
            stage = "";
        }
        else
        {
            enemyAi.PathFollow(enemyAi.speed);
            stage = "normal stage";
        }
    }
}
