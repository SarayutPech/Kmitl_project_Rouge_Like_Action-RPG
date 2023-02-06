using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Dex Skill3", menuName = "Skill/DEX/Dex Skill3")]
public class DEX_Skill3_Script : Skill
{
    private bool isSkillActive;
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.dex.GetValue() == 15 && !isSkillActive)
        {
            playerStats.critRate.AddModifier(5);
            isSkillActive = !isSkillActive;
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.dex.GetValue() < 15 && isSkillActive)
        {
            playerStats.critRate.RemoveModifier(5);
            isSkillActive = !isSkillActive;
        }
    }
}
