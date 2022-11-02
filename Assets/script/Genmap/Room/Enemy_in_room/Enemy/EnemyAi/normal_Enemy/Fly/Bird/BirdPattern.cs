using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPattern : EnemyPattern
{
    [SerializeField] private float knockbackTimenormalAttack = 0.5f;
    [SerializeField] private float deviderXForce = 10;
    [SerializeField] private float deviderYForce = 10;
    public Rigidbody2D rb;
    public float stop_chase_at = 4;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public override void todo()
    {

        if (base.thinkingTime_remaining <= 0)
            rand = Random.Range(0, 10);

        if (rand >= 0 && rand <= 3)
        {
            Dash();
            stage = "dash stage";
        }
        else if (rand >= 4 && rand <= 6)
        {
            Focus();
            stage = "focus stage";
        }
        else
        {
            enemyAi.PathFollow(enemyAi.speed);
            stage = "normal stage";
        }

        attack();
    }

    public void Dash()
    {
        enemyAi.PathFollow(enemyAi.speed * 5);
    }

    public void Focus()
    {
        enemyAi.PathFollow(enemyAi.speed / 3, stop_chase_at );
    }

    
    public void attack()
    {
        Collider2D playerCol = Physics2D.OverlapBox(shouldAttackBox.position, new Vector2(HitboxX, HitboxX), 0f, player);
        if (playerCol)
        {
            playerCol.GetComponent<player_movement>().knockbackTime = knockbackTimenormalAttack;
            playerCol.GetComponent<Rigidbody2D>().AddForce(new Vector2(rb.velocity.x / deviderXForce, rb.velocity.y / deviderYForce), ForceMode2D.Impulse);
            // HP -
            playerCol.GetComponent<Animator>().SetTrigger("gethit");
        }
    }

    public float ScaleX()
    {
        return transform.root.gameObject.transform.localScale.x;
    }
}
