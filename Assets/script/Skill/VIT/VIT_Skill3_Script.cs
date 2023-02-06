using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VIT Skill3", menuName = "Skill/VIT/VIT Skill3")]
public class VIT_Skill3_Script : Skill
{
    private bool isSkillActive;
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.vit.GetValue() == 15 && !isSkillActive)
        {
            playerStats.maxHealth += 20;
            isSkillActive = !isSkillActive;
        }

    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.vit.GetValue() < 15 && isSkillActive)
        {
            playerStats.maxHealth -= 20;
            isSkillActive = !isSkillActive;
        }
    }
}
