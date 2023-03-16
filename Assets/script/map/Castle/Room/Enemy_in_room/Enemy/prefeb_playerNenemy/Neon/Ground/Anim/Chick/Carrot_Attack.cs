using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot_Attack : MonoBehaviour
{
    [SerializeField] private HaveAttackAnimEnemy carrot;
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
        Collider2D playerCol = Physics2D.OverlapBox(carrot.shouldAttackBox.position, new Vector2(carrot.HitboxX, carrot.HitboxX), 0f, carrot.player);
        if (playerCol)
        {
            playerCol.GetComponent<player_movement>().knockbackTime = knockbackTimenormalAttack;
            // HP -
            playerCol.GetComponent<CharacterStats>().TakeDamage(dmg + levelManagerParameter.DmgBuffer);
            //Knockback
            playerCol.GetComponent<CharacterStats>().Knockback(new Vector2(knockbackX, knockbackY));
        }
    }
}
