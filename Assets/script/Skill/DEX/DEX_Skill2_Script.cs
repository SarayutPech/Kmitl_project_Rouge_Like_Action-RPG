using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weak Spot Strike", menuName = "Skill/DEX/Weak Spot Strike")]
public class DEX_Skill2_Script : Skill
{
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.dex.GetValue() == 10)
        {
            playerStats.critDamage.AddModifier(20);
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.dex.GetValue() < 10)
        {
            playerStats.critDamage.RemoveModifier(20);
        }
    }
}
