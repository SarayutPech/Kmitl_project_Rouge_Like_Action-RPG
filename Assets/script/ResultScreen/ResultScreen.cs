using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScreen : MonoBehaviour
{
    public int item_pickup, enemy_defeated, boss_defeated , floor_clear;

    public int exp_gain;

    private void Start()
    {
        ResetResult();
    }

    public void ResetResult()
    {
        item_pickup = 0;
        enemy_defeated = 0;
        boss_defeated = 0;
        floor_clear = 0;

        exp_gain = 0;
    }

    public void Increase_Item_Pickup()
    {
        item_pickup += 1;
    }

    public void Increase_Enemy_Defeated()
    {
        enemy_defeated += 1;
    }

    public void Increase_Boss_Defeated()
    {
        boss_defeated += 1;
    }

    public void Increase_Floor_Reach()
    {
        floor_clear += 1;
    }

    public int Calculate_EXP_Gain()
    {
        int exp_item = item_pickup * 2;
        int exp_enemy = enemy_defeated * 5;
        int exp_boss = boss_defeated * 50;
        int exp_floor = floor_clear * 10 ;

        exp_gain = exp_item + exp_enemy + exp_boss + exp_floor;

        return exp_gain;
    }


}
