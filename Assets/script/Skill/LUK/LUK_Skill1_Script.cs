using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Lucky Strike", menuName = "Skill/LUK/Lucky Strike")]
public class LUK_Skill1_Script : Skill
{
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.luk.GetValue() == 5)
        {
            playerStats.critRate.AddModifier(10);
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.luk.GetValue() < 5)
        {
            playerStats.critRate.RemoveModifier(10);
        }
    }
}
