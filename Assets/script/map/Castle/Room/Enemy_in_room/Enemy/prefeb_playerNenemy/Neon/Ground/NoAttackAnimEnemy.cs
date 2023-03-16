using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAttackAnimEnemy : EnemyPattern
{

    [SerializeField] private float knockbackY = 5f;
    [SerializeField] private float knockbackX = 5f;
    [SerializeField] private float knockbackTimenormalAttack = 0.1f;
    public int dmg;
    private LevelManagerParameter levelManagerParameter;

    private void Start()
    {
        levelManagerParameter = GameObject.Find("level manager").GetComponent<LevelManagerParameter>();
    }
    public override void todo()
    {
        enemyAi.PathFollow(enemyAi.speed);
        tackle();
    }

    public float ScaleX()
    {
        return transform.root.gameObject.transform.localScale.x;
    }

    public void tackle()
    {
        Collider2D playerCol = Physics2D.OverlapBox(shouldAttackBox.position, new Vector2(HitboxX, HitboxX), 0f, player);
        if (playerCol)
        {
            playerCol.GetComponent<player_movement>().knockbackTime = knockbackTimenormalAttack;
            // HP -
            playerCol.GetComponent<CharacterStats>().TakeDamage(dmg + levelManagerParameter.DmgBuffer);
            //Knockback
            playerCol.GetComponent<CharacterStats>().Knockback(new Vector2(knockbackX * ScaleX(), knockbackY));
        }
    }

}
