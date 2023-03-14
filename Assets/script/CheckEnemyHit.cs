using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyHit : MonoBehaviour
{

    public EquipmentManager equipmentManager;
    public PlayerStats charaStat;
    public PlayerAttack indexWeapon;
    public Vector2 playerHitbox;
    public Vector2 playerForceAttack;
    public Transform playerAttackHitbox;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        equipmentManager = GameObject.Find("GameManager").GetComponent<EquipmentManager>();
        charaStat = GetComponentInParent<PlayerStats>();
        indexWeapon = GetComponentInParent<PlayerAttack>();
        equipmentManager = EquipmentManager.instance;
    }

    public void CheckHit()
    {
        Collider2D[] enemyHit = Physics2D.OverlapBoxAll(playerAttackHitbox.position, playerHitbox, 0, enemyLayer);
        try
        {
            foreach (Collider2D i in enemyHit)
            {
                i.GetComponent<Rigidbody2D>().AddForce(equipmentManager.currentEquipCard[indexWeapon.indexWeapon].forceWeapon * ScaleX(), ForceMode2D.Impulse);
                //i.GetComponent<Animator>().SetTrigger("getHit");

                if (i.GetComponent<BossStat>())
                    i.GetComponent<BossStat>().setHp(charaStat.attack.GetValue());
                else if (i.GetComponent<EnemyStat>())
                    i.GetComponent<EnemyStat>().setHp(charaStat.attack.GetValue());
                Debug.Log("Attack Enemy " + i + " Enemy Take" + charaStat.attack.GetValue() + "Damage.");
            }
        }
        catch
        {
            Debug.Log("Cannot find Enemy");
        }
        
    }
    public float ScaleX()
    {
        return transform.root.gameObject.transform.localScale.x;
    }
}
