using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Str Skill2", menuName = "Skill/STR/Str Skill2")]
public class STR_Skill2_Script : Skill
{
    public override void Active()
    {

        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        player_movement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();

        if (playerStats.str.GetValue() == 10 && !this.isSkillActive)
        {
            movement.powerJumpisActive = true;
            this.isSkillActive = !this.isSkillActive;
        }


    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        player_movement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();


        if (playerStats.str.GetValue() < 10 && this.isSkillActive)
        {
            movement.powerJumpisActive = false;
            this.isSkillActive = !this.isSkillActive;
        }
    }

}
