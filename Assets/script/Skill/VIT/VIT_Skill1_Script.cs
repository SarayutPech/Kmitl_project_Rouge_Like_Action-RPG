using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Healthy", menuName = "Skill/VIT/Healthy")]
public class VIT_Skill1_Script : Skill
{
    private bool isSkillActive;
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.vit.GetValue() == 5 && !isSkillActive)
        {
            playerStats.skillHPBonus += 20;
            isSkillActive = !isSkillActive;
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.vit.GetValue() < 5 && isSkillActive)
        {
            playerStats.skillHPBonus -= 20;
            isSkillActive = !isSkillActive;
        }
    }
}
