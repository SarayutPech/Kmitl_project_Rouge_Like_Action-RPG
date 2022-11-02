using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    [SerializeField] private SkeletonPattern skeleton;
    [SerializeField] private float knockbackY = 5f;
    [SerializeField] private float knockbackX = 5f;
    [SerializeField] private float knockbackTimenormalAttack = 0.1f;


    public void normalAttack()
    {
        Collider2D playerCol = Physics2D.OverlapBox(skeleton.shouldAttackBox.position, new Vector2(skeleton.HitboxX, skeleton.HitboxX), 0f, skeleton.player);
        if (playerCol)
        {
            playerCol.GetComponent<player_movement>().knockbackTime = knockbackTimenormalAttack;
            playerCol.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockbackX * -ScaleX(), -knockbackY), ForceMode2D.Impulse);
            // HP -
            playerCol.GetComponent<Animator>().SetTrigger("gethit");
        }
    }

    public void SkillAttack()
    {
        Collider2D playerCol = Physics2D.OverlapBox(skeleton.shouldAttackBox.position, new Vector2(skeleton.HitboxX, skeleton.HitboxX), 0f, skeleton.player);
        if (playerCol)
        {
            playerCol.GetComponent<player_movement>().knockbackTime = knockbackTimenormalAttack;
            playerCol.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockbackX * -ScaleX(), knockbackY), ForceMode2D.Impulse);
            // HP -
            playerCol.GetComponent<Animator>().SetTrigger("gethit");
        }
    }

    public float ScaleX()
    {
        return transform.root.gameObject.transform.localScale.x;
    }
}
