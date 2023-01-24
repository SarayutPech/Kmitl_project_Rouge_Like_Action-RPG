using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantAttack : MonoBehaviour
{
    public Transform hitboxPos;
    public Vector2 hitboxSize;
    public LayerMask player;

    public int dmg;
    public void slash()
    {
        Collider2D playerCol = Physics2D.OverlapBox(hitboxPos.position, hitboxSize, 0f, player);
        if (playerCol)
        {
            playerCol.GetComponent<player_movement>().knockbackTime = 0.1f;
            // HP -
            playerCol.GetComponent<CharacterStats>().TakeDamage(dmg);
            playerCol.GetComponent<Animator>().SetTrigger("gethit");
        }
    }

    public void destroy()
    {
        Destroy(transform.parent.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(hitboxPos.position, hitboxSize);
    }
}
