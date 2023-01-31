using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Skill", menuName = "Skill/Skill")]
public class Skill : ScriptableObject
{
    public string skillname = "New Skill";
    public string skillDescription = "Description Skill";
    public enum StatusType { STR, VIT, AGI, DEX, LUK }
    public Sprite skillicon = null;
    public StatusType skillType;
    


    public virtual void Active()
    {
        // skill Active
        Debug.Log("Skill " + name + " Active");
    }
    public virtual void InActive()
    {
        // skill inActive
        Debug.Log("Skill " + name + " InActive");
    }
}
