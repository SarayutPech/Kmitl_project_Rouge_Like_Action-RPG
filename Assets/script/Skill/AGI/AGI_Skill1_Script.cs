using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoubleJump", menuName = "Skill/AGI/DoubleJump")]
public class AGI_Skill1_Script : Skill
{
    // Double Jump 
    public override void Active()
    {
        player_movement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();

        movement.SetDoubleJump(true);
    }

    public override void InActive()
    {
        player_movement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();

        movement.SetDoubleJump(false);
    }
}
