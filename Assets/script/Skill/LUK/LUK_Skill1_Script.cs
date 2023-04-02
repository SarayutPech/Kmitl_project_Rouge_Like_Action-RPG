using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Lucky Strike", menuName = "Skill/LUK/Lucky Strike")]
public class LUK_Skill1_Script : Skill
{
    public override void Active()
    {
        
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.luk.GetValue() == 5 && !this.isSkillActive)
        {
            playerStats.critRate.AddModifier(10);
            this.isSkillActive = !this.isSkillActive;
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.luk.GetValue() < 5 && this.isSkillActive)
        {
            playerStats.critRate.RemoveModifier(10);
            this.isSkillActive = !this.isSkillActive;
        }
    }
}
