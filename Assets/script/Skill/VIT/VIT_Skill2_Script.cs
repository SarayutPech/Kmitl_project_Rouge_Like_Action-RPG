using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VIT Skill2", menuName = "Skill/VIT/VIT Skill2")]
public class VIT_Skill2_Script : Skill
{
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.vit.GetValue() == 10)
        {
            playerStats.maxHealth += 20;
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.vit.GetValue() < 10)
        {
            playerStats.maxHealth -= 20;
        }
    }
}
