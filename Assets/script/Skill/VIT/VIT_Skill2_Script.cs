using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VIT Skill2", menuName = "Skill/VIT/VIT Skill2")]
public class VIT_Skill2_Script : Skill
{
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        CharacterStats charaStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        if (playerStats.vit.GetValue() == 10 && !this.isSkillActive)
        {
            charaStats.heavyArmorisActive = true;
            this.isSkillActive = !this.isSkillActive;
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        CharacterStats charaStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();

        if (playerStats.vit.GetValue() < 10 && this.isSkillActive)
        {
            charaStats.heavyArmorisActive = false;
            this.isSkillActive = !this.isSkillActive;
        }
    }
}
