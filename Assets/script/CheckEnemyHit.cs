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

    private bool isCrit = false;

    private MessageSpawner damageIndicator;
    // Start is called before the first frame update
    void Start()
    {
        equipmentManager = GameObject.Find("GameManager").GetComponent<EquipmentManager>();
        charaStat = GetComponentInParent<PlayerStats>();
        indexWeapon = GetComponentInParent<PlayerAttack>();
        damageIndicator = GetComponentInParent<MessageSpawner>();
        equipmentManager = EquipmentManager.instance;
    }

    public void CheckHit()
    {
        Collider2D[] enemyHit = Physics2D.OverlapBoxAll(playerAttackHitbox.position, playerHitbox, 0, enemyLayer);

        int damage = CheckCriticalHit(charaStat.attack.GetValue(), charaStat.critRate.GetValue(), charaStat.critDamage.GetValue());
        try
        {
            foreach (Collider2D i in enemyHit)
            {
                i.GetComponent<Rigidbody2D>().AddForce(equipmentManager.currentEquipCard[indexWeapon.indexWeapon].forceWeapon * ScaleX(), ForceMode2D.Impulse);
                //i.GetComponent<Animator>().SetTrigger("getHit");

                if (i.GetComponent<BossStat>())
                {
                    i.GetComponent<BossStat>().setHp(damage);
                    damageIndicator.EnemySpawnMessage(i, damage.ToString(), isCrit);
                }                                  
                else if (i.GetComponent<EnemyStat>())
                {
                    i.GetComponent<EnemyStat>().setHp(damage); 
                    damageIndicator.EnemySpawnMessage(i, damage.ToString(), isCrit);
                }
                    
                Debug.Log("Attack Enemy " + i + " Enemy Take" + damage + "Damage.");
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

    public int CheckCriticalHit(int attack , int crit_rate , int crit_dmg)
    {
        float damageDeal;

        float critChance = (float)crit_rate/100;
        float critDmg = (float)crit_dmg / 100;

        float randValue = Random.value;
        if (randValue < critChance)
        {
            damageDeal = attack * (1 + critDmg);
            isCrit = true;
        }
        else
        {
            damageDeal = (float)attack;
            isCrit = false;
        }

        return (int)damageDeal;
    }
}
