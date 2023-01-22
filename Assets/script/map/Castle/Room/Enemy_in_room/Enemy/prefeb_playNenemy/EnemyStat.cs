using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int MaxHp;
    [SerializeField] private Animator animator;

    public HpBar hpBar;

    private LevelManagerParameter levelManagerParameter;
    private void Awake()
    {
        levelManagerParameter = GameObject.Find("level manager").GetComponent<LevelManagerParameter>();
    }

    private void Start()
    {
        hp = MaxHp + levelManagerParameter.HpBuffer;
        hpBar.setHpBar(MaxHp, MaxHp, false);
        hpBar.setHpBar(MaxHp, MaxHp, false);
    }

    public void setHp(int dmg)
    {
        hp -= dmg;
        hpBar.setHpBar(hp, MaxHp, true);
        if (hp <= 0)
            Die();
    }

    public void Die()
    {
        gameObject.GetComponent<EnemyAi>().enabled = false;
        animator.SetBool("Die",true);
        animator.SetTrigger("isDie");
    }

    
}
