using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Focus", menuName = "Skill/DEX/Focus")]
public class DEX_Skill1_Script : Skill
{
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.dex.GetValue() == 5 && !this.isSkillActive)
        {
            playerStats.critRate.AddModifier(5);
            this.isSkillActive = !this.isSkillActive;
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.dex.GetValue() < 5 && this.isSkillActive)
        {
            playerStats.critRate.RemoveModifier(5);
            this.isSkillActive = !this.isSkillActive;
        }
    }
}
