using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraAttackScript : MonoBehaviour
{

    Vector2 skillKnockBack = new Vector2(1.0f, 0.0f);
    Vector2 skillHitbox = new Vector2(1.0f, 1.0f);   
    private PlayerStats charaStat;
    private MessageSpawner damageIndicator;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckImpact()
    {
        charaStat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        damageIndicator = GameObject.FindGameObjectWithTag("Player").GetComponent<MessageSpawner>();
        Collider2D[] enemyHit = Physics2D.OverlapBoxAll(gameObject.transform.position, skillHitbox, 0, enemyLayer);
        int skillDamage = (int)(charaStat.attack.GetValue() * 1.1);

        foreach (Collider2D i in enemyHit)
        {
            i.GetComponent<Rigidbody2D>().AddForce(skillKnockBack * ScaleX(), ForceMode2D.Impulse);
            //i.GetComponent<Animator>().SetTrigger("getHit");

            if (i.GetComponent<BossStat>())
            {
                i.GetComponent<BossStat>().setHp(skillDamage);
                damageIndicator.EnemySpawnSkillMessage(i, skillDamage.ToString());
            }
            else if (i.GetComponent<EnemyStat>())
            {
                i.GetComponent<EnemyStat>().setHp(skillDamage);
                damageIndicator.EnemySpawnSkillMessage(i, skillDamage.ToString());
            }

            Debug.Log("Attack Enemy " + i + " Enemy Take" + skillDamage + "Damage.");
        }

    }

    void SkillEnd()
    {

        Destroy(gameObject);
    }

    public float ScaleX()
    {
        return transform.root.gameObject.transform.localScale.x;
    }
}
