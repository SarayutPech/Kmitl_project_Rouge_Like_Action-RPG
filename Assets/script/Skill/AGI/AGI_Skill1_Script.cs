using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoubleJump", menuName = "Skill/AGI/DoubleJump")]
public class AGI_Skill1_Script : Skill
{
    private bool isSkillActive;
    // Double Jump 
    public override void Active()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        player_movement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();

        if (playerStats.agi.GetValue() == 5 && !isSkillActive)
        {
            
            movement.SetDoubleJump(true);
            isSkillActive = !isSkillActive;
        }
        
    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        player_movement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();
        if (playerStats.agi.GetValue() < 5 && isSkillActive)
        {        
            movement.SetDoubleJump(false);
            isSkillActive = !isSkillActive;
        }
        
    }
}
