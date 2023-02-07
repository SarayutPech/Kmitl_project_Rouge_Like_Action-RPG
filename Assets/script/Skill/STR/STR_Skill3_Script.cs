using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Str Skill3", menuName = "Skill/STR/Str Skill3")]
public class STR_Skill3_Script : Skill
{
    private bool isSkillActive;
    public override void Active()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        PlayerAttack playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();

        if (playerStats.str.GetValue() == 15 && !isSkillActive)
        {
            playerAttack.extraAttackisActive = true;
            isSkillActive = !isSkillActive;
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        PlayerAttack playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();

        if (playerStats.str.GetValue() < 15 && isSkillActive)
        {
            playerAttack.extraAttackisActive = false;
            isSkillActive = !isSkillActive;
        }
    }
}
