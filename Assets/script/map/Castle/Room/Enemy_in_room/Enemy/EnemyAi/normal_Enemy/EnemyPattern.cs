using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyPattern : MonoBehaviour
{
    public EnemyAi enemyAi;
    [Header("Stage")]
    public string stage;
    public int rand = 0;

    [Header("Hitbox detect")]
    public Transform shouldAttackBox;
    public float HitboxX = 0.1f;
    public float HitboxY = 0.1f;
    public LayerMask player;

    [Header("Animation")]
    public Animator animator;

    [Header("Pattern Script")]
    [SerializeField] private float thinkingTime_fixed = 5;
    public float thinkingTime_remaining = 0;

    private void Start()
    {
        //Thinking times
        thinkingTime_remaining = thinkingTime_fixed;
        enemyAi = GetComponent<EnemyAi>();
    }

    private void Update()
    {

        enemyStage();
        todo();   
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

    public bool shouldAttack()
    {
        return Physics2D.OverlapBox(shouldAttackBox.position, new Vector2(HitboxX, HitboxY), 0f,player);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(shouldAttackBox.position, new Vector2(HitboxX, HitboxY));
    }
}
