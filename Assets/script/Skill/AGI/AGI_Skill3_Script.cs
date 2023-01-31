using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveSpeed", menuName = "Skill/AGI/MoveSpeed")]
public class AGI_Skill3_Script : Skill
{
    public override void Active()
    {
        
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if(playerStats.agi.GetValue() <= 5)
        {
            playerStats.moveSpeed.AddModifier(10);
        }
               
        
    }

    public override void InActive()
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (playerStats.agi.GetValue() < 5)
        {
            playerStats.moveSpeed.RemoveModifier(10);
        }
    }
}
