using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightPattern : EnemyPattern
{

    [Header("Status")]
    public bool canwarp = false;
    public float warp_cd_fixed = 6;
    public float warp_cd_remain = 0;
    public bool canHeal = false;



    private Rigidbody2D rb;
    Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    public void attack()
    {
        
    }

    public override void todo()
    {
        skill_cd_reset();
        if (thinkingTime_remaining <= 0)
            rand = Random.Range(0, 10);

        if (rand >= 0 && rand <= 3 && canHeal)
        {
            Heal();
            stage = "healing stage";
        }
        else if (rand >= 4 && rand <= 5 && canwarp)
        {
            warp();
            stage = "warp stage";
        }
        else
        {
            enemyAi.PathFollow(enemyAi.speed);
            stage = "normal stage";
        }
    }

    public void Heal()
    {
        idle();
            // เว้นไว้ใส่สกิล

        canHeal = false;
    }

    public void warp()
    {
        canwarp = false;
        warp_cd_remain = 0;
        transform.position = new Vector2(target.position.x, target.position.y + 2);
        rand = -1;
    }

    private void skill_cd_reset()
    {
        if( canwarp == false)
        {
            warp_cd_remain += Time.deltaTime;
            if (warp_cd_remain >= warp_cd_fixed)
                canwarp = true;
        }
    }

}
