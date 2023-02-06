using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    private Rigidbody2D rb;
    public HeroPattern hero;
    //public HeroPattern hero;
    public bool enchantAttack;
    [SerializeField] private float knockbackY = 5f;
    [SerializeField] private float knockbackX = 5f;
    [SerializeField] private float knockbackTimenormalAttack = 0.3f;
    public int dmg = 10;

    public GameObject rootOb;
    public Transform slashPos;
    public Transform EncAtt1Pos;

    private LevelManagerParameter levelManagerParameter;

    
    public GameObject EncSlash;
    public GameObject EncAtt3;
    public GameObject EncAtt1;
    private void Awake()
    {
        levelManagerParameter = GameObject.Find("level manager").GetComponent<LevelManagerParameter>();
        rb = rootOb.GetComponent<Rigidbody2D>();
    }

    public void attack1()
    {
        attack();
        if(enchantAttack)
        {
            if(ScaleX() > 0)
                Instantiate(EncAtt1, EncAtt1Pos.position, Quaternion.Euler(0f, 180f, 0f));
            else
                Instantiate(EncAtt1, EncAtt1Pos.position, Quaternion.Euler(0f, 0f, 0f));
        }

        Debug.Log(180f * (rootOb.transform.localScale.x / 4));
    }

    public void attack2()
    {
        attack();
        if (enchantAttack)
        {
            if (ScaleX() > 0)
                Instantiate(EncSlash, EncAtt1Pos.position, Quaternion.Euler(0f, 180f, 0f));
            else
                Instantiate(EncSlash, EncAtt1Pos.position, Quaternion.Euler(0f, 0f, 0f));
        }
    }

    public void attack3()
    {
        attack();
        if (enchantAttack)
        {
            Instantiate(EncAtt3, new Vector3(playerPos().x, -3.75f, -1), Quaternion.identity);
        }
    }

    public void roll()
    {
        rb.AddForce(new Vector2(4f * -ScaleX(), 0), ForceMode2D.Impulse);
    }

    public void immuneStart()
    {
        // immuneDmg Layer index : 15
        rootOb.layer = 15;
    }

    public void immuneEnd()
    {
        // Enemy Layer index : 3
        rootOb.layer = 3;
    }

    public void blocking()
    {
        // Wall Layer index
        rootOb.layer = 8;
    }

    public float ScaleX()
    {
        return transform.root.gameObject.transform.localScale.x;
    }

    private void attack()
    {
        Collider2D playerCol = Physics2D.OverlapBox(hero.shouldAttackBox.position, new Vector2(hero.HitboxX, hero.HitboxX), 0f, hero.player);
        if (playerCol)
        {
            playerCol.GetComponent<player_movement>().knockbackTime = knockbackTimenormalAttack;
            playerCol.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockbackX * ScaleX() / 2, -knockbackY), ForceMode2D.Impulse);
            // HP -
            playerCol.GetComponent<CharacterStats>().TakeDamage(dmg - levelManagerParameter.DmgBuffer);
            playerCol.GetComponent<Animator>().SetTrigger("gethit");
        
        }
    }

    private Vector3 playerPos()
    {
        return GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    
}
