using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Dex Skill3", menuName = "Skill/DEX/Dex Skill3")]
public class DEX_Skill3_Script : Skill
{
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.dex.GetValue() == 15)
        {
            playerStats.critRate.AddModifier(5);
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.dex.GetValue() < 15)
        {
            playerStats.critRate.RemoveModifier(5);
        }
    }
}
