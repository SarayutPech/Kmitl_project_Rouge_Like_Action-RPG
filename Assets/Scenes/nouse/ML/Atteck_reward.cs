using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atteck_reward : MonoBehaviour
{
    private Rigidbody2D rb;
    public BossFollowPlayerML BossML;
    public bool enchantAttack;
    [SerializeField] private float knockbackY = 5f;
    [SerializeField] private float knockbackX = 5f;
    [SerializeField] private float knockbackTimenormalAttack = 0.3f;
    public int dmg = 10;

    public GameObject RewardColor;
    public Color win;
    public Color lose;

    public Vector2 hitBox;
    public Transform hitBoxPos;
    public LayerMask player;
    public LayerMask falseLayer;

    public GameObject rootOb;
    public Transform slashPos;
    public Transform EncAtt1Pos;

    private LevelManagerParameter levelManagerParameter;

    
    public GameObject EncSlash;
    public GameObject EncAtt3;
    public GameObject EncAtt1;

    public float time;
    private void Awake()
    {
        levelManagerParameter = GameObject.Find("level manager").GetComponent<LevelManagerParameter>();
        rb = rootOb.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        time += Time.deltaTime;
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

        //Debug.Log(180f * (rootOb.transform.localScale.x / 4));
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
        Collider2D playerCol = Physics2D.OverlapBox(hitBoxPos.position , new Vector2(hitBox.x, hitBox.y), 0f, player);
        if (playerCol)
        {
            playerCol.GetComponent<player_movement>().knockbackTime = knockbackTimenormalAttack;
            playerCol.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockbackX * ScaleX() / 2, -knockbackY), ForceMode2D.Impulse);
            // HP -
            if(playerCol.GetComponent<CharacterStats>())
                playerCol.GetComponent<CharacterStats>().TakeDamage(dmg - levelManagerParameter.DmgBuffer);
            playerCol.GetComponent<Animator>().SetTrigger("gethit");
            BossML.AddReward(300);
            BossML.EndEpisode();
            //Debug.Log(+1);
            RewardColor.GetComponent<SpriteRenderer>().color = win;
        }

        Collider2D dontAttackThis = Physics2D.OverlapBox(hitBoxPos.position, new Vector2(hitBox.x, hitBox.y), 0f, falseLayer);
        if (dontAttackThis)
        {
            BossML.AddReward(-150);
            BossML.EndEpisode();
            //Debug.Log(-1);
            RewardColor.GetComponent<SpriteRenderer>().color = lose;
        }
        
    }

    private Vector3 playerPos()
    {
        return GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    
}
