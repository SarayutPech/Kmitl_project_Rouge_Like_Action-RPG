using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Str Skill2", menuName = "Skill/STR/Str Skill2")]
public class STR_Skill2_Script : Skill
{
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.str.GetValue() == 10)
        {
            playerStats.attack.AddModifier(20);
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.str.GetValue() < 10)
        {
            playerStats.attack.RemoveModifier(20);
        }
    }
}
