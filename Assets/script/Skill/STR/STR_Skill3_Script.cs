using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Str Skill3", menuName = "Skill/STR/Str Skill3")]
public class STR_Skill3_Script : Skill
{
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.str.GetValue() == 15)
        {
            playerStats.attack.AddModifier(20);
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.str.GetValue() < 15)
        {
            playerStats.attack.RemoveModifier(20);
        }
    }
}
