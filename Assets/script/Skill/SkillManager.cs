using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

    public Skill StrSkill1, StrSkill2, StrSkill3, StrSkill4;
    public Skill VitSkill1, VitSkill2, VitSkill3, VitSkill4;
    public Skill AgiSkill1, AgiSkill2, AgiSkill3, AgiSkill4;
    public Skill DexSkill1, DexSkill2, DexSkill3, DexSkill4;
    public Skill LukSkill1, LukSkill2, LukSkill3, LukSkill4;

    private UISkillController uiSkill;
    public PlayerStats playerStats;
    private void Awake()
    {
        uiSkill = GameObject.Find("GameManager").GetComponent<UISkillController>();      
    }

    // Update is called once per frame

    public void CheckSkillActive()
    {
        int strStat = playerStats.str.GetValue();
        int vitStat = playerStats.vit.GetValue();
        int agiStat = playerStats.agi.GetValue();
        int dexStat = playerStats.dex.GetValue();
        int lukStat = playerStats.luk.GetValue();

        //STR
        if(strStat >= 5 && strStat < 10)
        {
            StrSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.StrSkill1);
            StrSkill2.InActive();
            uiSkill.SetSkillInActive(uiSkill.StrSkill2);
            StrSkill3.InActive();
            uiSkill.SetSkillInActive(uiSkill.StrSkill3);
            StrSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.StrSkill4);
        }
        else if(strStat >= 10 && strStat < 15)
        {
            StrSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.StrSkill1);
            StrSkill2.Active();
            uiSkill.SetSkillActive(uiSkill.StrSkill2);
            StrSkill3.InActive();
            uiSkill.SetSkillInActive(uiSkill.StrSkill3);
            StrSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.StrSkill4);
        }
        else if (strStat >= 15 && strStat < 20)
        {
            StrSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.StrSkill1);
            StrSkill2.Active();
            uiSkill.SetSkillActive(uiSkill.StrSkill2);
            StrSkill3.Active();
            uiSkill.SetSkillActive(uiSkill.StrSkill3);
            StrSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.StrSkill4);
        }
        else if (strStat >= 20)
        {
            StrSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.StrSkill1);
            StrSkill2.Active();
            uiSkill.SetSkillActive(uiSkill.StrSkill2);
            StrSkill3.Active();
            uiSkill.SetSkillActive(uiSkill.StrSkill3);
            StrSkill4.Active();
            uiSkill.SetSkillActive(uiSkill.StrSkill4);
        }
        else
        {
            StrSkill1.InActive();
            uiSkill.SetSkillInActive(uiSkill.StrSkill1);
            StrSkill2.InActive();
            uiSkill.SetSkillInActive(uiSkill.StrSkill2);
            StrSkill3.InActive();
            uiSkill.SetSkillInActive(uiSkill.StrSkill3);
            StrSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.StrSkill4);
        }
    }
}
