using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Focus", menuName = "Skill/DEX/Focus")]
public class DEX_Skill1_Script : Skill
{
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.dex.GetValue() == 5)
        {
            playerStats.critRate.AddModifier(5);
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.dex.GetValue() < 5)
        {
            playerStats.critRate.RemoveModifier(5);
        }
    }
}
