using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttack : MonoBehaviour
{
    [SerializeField] private KnightPattern knight;
    [SerializeField] private float knockbackY = 5f;
    [SerializeField] private float knockbackX = 5f;
    [SerializeField] private float knockbackTimenormalAttack = 0.1f;
    public int dmg;
    [SerializeField] Rigidbody2D RootRb;

    private LevelManagerParameter levelManagerParameter;
    private void Awake()
    {
        levelManagerParameter = GameObject.Find("level manager").GetComponent<LevelManagerParameter>();
    }

    public void normalAttack()
    {
        Collider2D playerCol = Physics2D.OverlapBox(knight.shouldAttackBox.position, new Vector2(knight.HitboxX, knight.HitboxX), 0f, knight.player);
        if (playerCol)
        {
            playerCol.GetComponent<player_movement>().knockbackTime = knockbackTimenormalAttack;
            // HP -
            playerCol.GetComponent<CharacterStats>().TakeDamage(dmg + levelManagerParameter.DmgBuffer);
            //Knockback
            playerCol.GetComponent<CharacterStats>().Knockback(new Vector2(knockbackX * ScaleX(), knockbackY));
        }
    }

    public float ScaleX()
    {
        return transform.root.gameObject.transform.localScale.x;
    }
}
