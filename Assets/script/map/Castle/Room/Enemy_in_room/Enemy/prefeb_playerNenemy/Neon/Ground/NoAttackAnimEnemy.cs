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
    [SerializeField] private float attDelayBase = 3;
    [SerializeField] private float attDelayCount = 3;
    public Color baseColor;
    public Color attColor;

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
        if(attDelayCount <= 0)
        {
            GameObject sprite = GetChildWithName(gameObject, "Enemy GFX");
            sprite.GetComponent<SpriteRenderer>().color = attColor;
            Collider2D playerCol = Physics2D.OverlapBox(shouldAttackBox.position, new Vector2(HitboxX, HitboxX), 0f, player);
            if (playerCol)
            {
                playerCol.GetComponent<player_movement>().knockbackTime = knockbackTimenormalAttack;
                // HP -
                playerCol.GetComponent<CharacterStats>().TakeDamage(dmg + levelManagerParameter.DmgBuffer);
                //Knockback
                playerCol.GetComponent<CharacterStats>().Knockback(new Vector2(knockbackX * ScaleX(), knockbackY));

                attDelayCount = attDelayBase;
            }
        }
        else
        {
            attDelayCount -= Time.deltaTime;
            GameObject sprite = GetChildWithName(gameObject, "Enemy GFX");
            sprite.GetComponent<SpriteRenderer>().color = baseColor;
        }
    }

    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }

}
