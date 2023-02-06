using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "Skill/AGI/Dash")]
public class AGI_Skill2_Script : Skill
{
    private bool isSkillActive;
    // Dash 
    public override void Active()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        player_movement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();

        if (playerStats.agi.GetValue() == 10 && !isSkillActive)
        {

            movement.SetDash(true);
            isSkillActive = !isSkillActive;
        }
       
    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        player_movement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();
        if (playerStats.agi.GetValue() < 10 && isSkillActive)
        {
            movement.SetDash(false);
            isSkillActive = !isSkillActive;
        }

        
    }
}