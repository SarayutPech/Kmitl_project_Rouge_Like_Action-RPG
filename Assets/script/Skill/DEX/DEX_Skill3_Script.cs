using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Dex Skill3", menuName = "Skill/DEX/Dex Skill3")]
public class DEX_Skill3_Script : Skill
{
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        PlayerAttack playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();

        if (playerStats.dex.GetValue() == 15 && !this.isSkillActive)
        {
            playerAttack.comboStrikeisActive = true;
            this.isSkillActive = !this.isSkillActive;
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        PlayerAttack playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();

        if (playerStats.dex.GetValue() < 15 && this.isSkillActive)
        {
            playerAttack.comboStrikeisActive = false;
            this.isSkillActive = !this.isSkillActive;
        }
    }
}
