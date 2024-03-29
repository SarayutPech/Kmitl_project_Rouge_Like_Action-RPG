using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreonAttack : MonoBehaviour
{
    [SerializeField] private LoreonPattern loreon;
    [SerializeField] private float knockbackY = 5f;
    [SerializeField] private float knockbackX = 5f;
    [SerializeField] private float knockbackTimenormalAttack = 0.1f;
    public int dmg;


    private LevelManagerParameter levelManagerParameter;
    private void Awake()
    {
        levelManagerParameter = GameObject.Find("level manager").GetComponent<LevelManagerParameter>();
    }


    public void normalAttack()
    {
        Collider2D playerCol = Physics2D.OverlapBox(loreon.shouldAttackBox.position,new Vector2( loreon.HitboxX, loreon.HitboxX), 0f, loreon.player);
        if (playerCol)
        {
            playerCol.GetComponent<player_movement>().knockbackTime = knockbackTimenormalAttack;
            // HP -
            playerCol.GetComponent<CharacterStats>().TakeDamage(dmg - levelManagerParameter.DmgBuffer);
            //Knockback
            playerCol.GetComponent<CharacterStats>().Knockback(new Vector2(knockbackX * ScaleX(), knockbackY));
        }
    }

    public void SkillAttack()
    {
        Collider2D playerCol = Physics2D.OverlapBox(loreon.shouldAttackBox.position, new Vector2(loreon.HitboxX, loreon.HitboxX), 0f,loreon.player);
        if (playerCol)
        {
            playerCol.GetComponent<player_movement>().knockbackTime = knockbackTimenormalAttack * 3;
            playerCol.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockbackX * ScaleX(), knockbackY), ForceMode2D.Impulse);
            // HP -
            playerCol.GetComponent<CharacterStats>().TakeDamage(dmg - levelManagerParameter.DmgBuffer);
            playerCol.GetComponent<Animator>().SetTrigger("gethit");
        }
    }

    public float ScaleX()
    {
        return transform.root.gameObject.transform.localScale.x;
    }
}
