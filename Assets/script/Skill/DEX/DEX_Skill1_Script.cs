using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Focus", menuName = "Skill/DEX/Focus")]
public class DEX_Skill1_Script : Skill
{
    private bool isSkillActive;
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.dex.GetValue() == 5 && !isSkillActive)
        {
            playerStats.critRate.AddModifier(5);
            isSkillActive = !isSkillActive;
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.dex.GetValue() < 5 && isSkillActive)
        {
            playerStats.critRate.RemoveModifier(5);
            isSkillActive = !isSkillActive;
        }
    }
}
