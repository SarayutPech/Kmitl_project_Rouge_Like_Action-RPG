using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "Skill/AGI/Dash")]
public class AGI_Skill2_Script : Skill
{
    // Dash 
    public override void Active()
    {
        player_movement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();

        movement.SetDash(true);
    }

    public override void InActive()
    {
        player_movement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();

        movement.SetDash(false);
    }
}