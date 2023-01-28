using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPmanager : MonoBehaviour
{

    public int currentEXP, targetEXP, level , statPoint;

    public static EXPmanager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddEXP(int exp)
    {
        currentEXP += exp;

        while(currentEXP >= targetEXP)
        {
            currentEXP = currentEXP - targetEXP;
            if(level >= 30)
            {
                currentEXP = 0;
                Debug.Log("Level Max");
            }
            else
            {
                level++;
                statPoint++;
                targetEXP += targetEXP / 20; //increase require exp 20%
                Debug.Log("Level Uppu");
            }
            
            
        }
    }
}
