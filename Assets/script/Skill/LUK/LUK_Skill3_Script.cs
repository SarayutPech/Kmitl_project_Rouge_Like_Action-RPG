using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LUK Skill3", menuName = "Skill/LUK/LUK Skill3")]
public class LUK_Skill3_Script : Skill
{
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.luk.GetValue() == 15)
        {
            playerStats.dropRate.AddModifier(20);
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.luk.GetValue() < 15)
        {
            playerStats.dropRate.RemoveModifier(20);
        }
    }
}
