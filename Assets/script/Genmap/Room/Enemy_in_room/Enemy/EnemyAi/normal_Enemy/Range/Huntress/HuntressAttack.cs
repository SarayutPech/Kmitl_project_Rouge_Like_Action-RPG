using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntressAttack : MonoBehaviour
{
    [SerializeField] private HuntressPattern huntress;
    [SerializeField] private GameObject attack;

    public void normalAttack()
    {
        Collider2D playerCol = Physics2D.OverlapBox(huntress.shouldAttackBox.position, new Vector2(huntress.HitboxX, huntress.HitboxX), 0f, huntress.player);
        if (playerCol)
        {
            Instantiate(attack,new Vector2(playerCol.transform.position.x, playerCol.transform.position.y), Quaternion.identity);
        }
    }
}
