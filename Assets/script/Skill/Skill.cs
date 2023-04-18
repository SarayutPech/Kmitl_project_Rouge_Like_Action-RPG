using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Skill", menuName = "Skill/Skill")]
public abstract class Skill : ScriptableObject
{
    public string skillname = "New Skill";
    public string skillDescription = "Description Skill";
    public enum StatusType { STR, VIT, AGI, DEX, LUK }
    public Sprite skillicon = null;
    public StatusType skillType;

    public bool isSkillActive;


    public abstract void Active();
   
    public abstract void InActive();
    
}
