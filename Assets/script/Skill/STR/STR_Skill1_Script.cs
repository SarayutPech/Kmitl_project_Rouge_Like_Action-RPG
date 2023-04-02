using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bonus Attack", menuName = "Skill/STR/Bonus Attack")]
public class STR_Skill1_Script : Skill
{
    
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.str.GetValue() == 5 && !this.isSkillActive)
        {
            playerStats.attack.AddModifier(20);
            this.isSkillActive = !this.isSkillActive;
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.str.GetValue() < 5 && this.isSkillActive)
        {
            playerStats.attack.RemoveModifier(20);
            this.isSkillActive = !this.isSkillActive;
        }
    }
}
