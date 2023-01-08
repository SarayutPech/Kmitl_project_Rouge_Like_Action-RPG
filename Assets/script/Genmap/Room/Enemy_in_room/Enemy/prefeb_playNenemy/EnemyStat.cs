using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float MaxHp;
    [SerializeField] private Animator animator;

    public HpBar hpBar;



    private void Start()
    {
        hp = MaxHp;
        hpBar.setHpBar(MaxHp, MaxHp, false);
        hpBar.setHpBar(MaxHp, MaxHp, false);
    }

    public void setHp(float dmg)
    {
        hp -= dmg;
        hpBar.setHpBar(hp, MaxHp, true);
        if (hp <= 0)
            Die();
    }

    public void Die()
    {
        gameObject.GetComponent<EnemyAi>().enabled = false;
        animator.SetTrigger("isDie");
    }

    
}
