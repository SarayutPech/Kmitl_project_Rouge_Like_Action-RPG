using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Treature Hunter", menuName = "Skill/LUK/Treature Hunter")]
public class LUK_Skill2_Script : Skill
{
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.luk.GetValue() == 10 && !this.isSkillActive)
        {
            playerStats.dropRate.AddModifier(20);
            this.isSkillActive = !this.isSkillActive;
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.luk.GetValue() < 10 && this.isSkillActive)
        {
            playerStats.dropRate.RemoveModifier(20);
            this.isSkillActive = !this.isSkillActive;
        }
    }
}
