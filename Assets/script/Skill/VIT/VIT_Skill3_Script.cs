using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VIT Skill3", menuName = "Skill/VIT/VIT Skill3")]
public class VIT_Skill3_Script : Skill
{
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        CharacterStats charaStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();

        if (playerStats.vit.GetValue() == 15 && !this.isSkillActive)
        {

            charaStats.deflectisActive = true;
            this.isSkillActive = !this.isSkillActive;
        }

    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        CharacterStats charaStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();

        if (playerStats.vit.GetValue() < 15 && this.isSkillActive)
        {
            charaStats.deflectisActive = false;
            this.isSkillActive = !this.isSkillActive;
        }
    }
}
