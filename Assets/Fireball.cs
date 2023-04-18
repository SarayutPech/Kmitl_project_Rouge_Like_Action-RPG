using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public int dmg;
    public float lifeTime;
    public Vector3 dir;

    private LevelManagerParameter levelManagerParameter;
    public Transform pos;
    public float HitboxX, HitboxY;
    public LayerMask player;
    public Animator anim;

    public bool canHit = true;

    private void Start()
    {
        levelManagerParameter = GameObject.Find("level manager").GetComponent<LevelManagerParameter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime >= 0)
        {
            move(dir);
;           lifeTime -= Time.deltaTime;
        }
        else
            Destroy(gameObject);

        if (canHit)
        {
            Collider2D playerCol = Physics2D.OverlapBox(pos.position, new Vector2(HitboxX, HitboxX), 0f, player);
            if (playerCol)
            {
                canHit = false;
                playerCol.GetComponent<CharacterStats>().TakeDamage(dmg + levelManagerParameter.DmgBuffer);
                anim.SetTrigger("Explosions");

                //Knockback
            }
        }
        
    }

    public void move(Vector3 dir)
    {
        transform.position = transform.position + dir *speed *  Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pos.position, new Vector2(HitboxX, HitboxY));
    }
}
