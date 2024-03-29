using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossStat : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int MaxHp;
    [SerializeField] private Animator animator;
    public Atteck_reward heroAttack;

    public BossHPBar hpBar;

    private LevelManagerParameter levelManagerParameter;
    private void Awake()
    {
        levelManagerParameter = GameObject.Find("level manager").GetComponent<LevelManagerParameter>();
    }

    private void Start()
    {
        MaxHp = MaxHp + levelManagerParameter.HpBuffer;
        hp = MaxHp;
        hpBar.setHpBar(hp, MaxHp);
        hpBar.setHpBar(hp, MaxHp);
    }

    public void setHp(int dmg)
    {
        hp -= dmg;
        hpBar.setHpBar(hp, MaxHp);

        try
        {
            if (hp < MaxHp * 30 / 100)
                heroAttack.enchantAttack = true;
        }
        catch
        {
            Debug.Log("This Hero dont have enchantAttack");
        }
        

        if (hp <= 0)
            Die();
    }

    public void Die()
    {
        gameObject.GetComponent<EnemyAi>().enabled = false;
        animator.SetTrigger("isDie");
        animator.SetBool("Die", true);

    }
}
