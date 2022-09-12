using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightPattern : MonoBehaviour
{
    public EnemyAi enemyAi;
    [Header("Stage")]
    public string stage;
    public int rand = 0;

    [Header("Status")]
    public bool canwarp = false;
    public float warp_cd_fixed = 6;
    public float warp_cd_remain = 0;
    public bool canHeal = false;

    [Header("Animation")]
    public Animator animator;
    public bool die = false;

    [Header("Pattern Script")]
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

        skill_cd_reset();

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

    public void attack()
    {
        
    }

    public void idle()
    {
        animator.SetBool("isRunning", false);
    }

    public void todo()
    {
        
        if (thinkingTime_remaining <= 0)
            rand = Random.Range(0, 10);

        if (rand >= 0 && rand <= 3 && canHeal)
        {
            Heal();
            stage = "healing stage";
        }
        else if (rand >= 4 && rand <= 5 && canwarp)
        {
            warp();
            stage = "warp stage";
        }
        else
        {
            enemyAi.PathFollow(enemyAi.speed);
            stage = "normal stage";
        }
    }

    public void Heal()
    {
        idle();
            // เว้นไว้ใส่สกิล

        canHeal = false;
    }

    public void warp()
    {
        canwarp = false;
        warp_cd_remain = 0;
        transform.position = new Vector2(target.position.x, target.position.y + 2);
        rand = -1;
    }

    private void skill_cd_reset()
    {
        if( canwarp == false)
        {
            warp_cd_remain += Time.deltaTime;
            if (warp_cd_remain >= warp_cd_fixed)
                canwarp = true;
        }
    }

}
