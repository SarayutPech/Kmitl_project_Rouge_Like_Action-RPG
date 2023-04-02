using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoubleJump", menuName = "Skill/AGI/DoubleJump")]
public class AGI_Skill1_Script : Skill
{
   
    // Double Jump 
    public override void Active()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        player_movement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();

        if (playerStats.agi.GetValue() == 5 && !this.isSkillActive)
        {
            
            movement.SetDoubleJump(true);
            this.isSkillActive = !this.isSkillActive;
        }
        
    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        player_movement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();
        if (playerStats.agi.GetValue() < 5 && this.isSkillActive)
        {        
            movement.SetDoubleJump(false);
            this.isSkillActive = !this.isSkillActive;
        }
        
    }
}
