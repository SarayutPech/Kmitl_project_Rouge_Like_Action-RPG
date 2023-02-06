using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Lucky Strike", menuName = "Skill/LUK/Lucky Strike")]
public class LUK_Skill1_Script : Skill
{
    private bool isSkillActive;
    public override void Active()
    {
        
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.luk.GetValue() == 5 && !isSkillActive)
        {
            playerStats.critRate.AddModifier(10);
            isSkillActive = !isSkillActive;
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.luk.GetValue() < 5 && isSkillActive)
        {
            playerStats.critRate.RemoveModifier(10);
            isSkillActive = !isSkillActive;
        }
    }
}
