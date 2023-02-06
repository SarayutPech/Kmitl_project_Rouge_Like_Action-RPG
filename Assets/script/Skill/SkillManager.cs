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

    public void CheckSkillActive(string stat)
    {

        if (stat == "STR")
        {
            int strStat = playerStats.str.GetValue();
            StrSkillCheck(strStat);
        }
        else if (stat == "VIT")
        {
            int vitStat = playerStats.vit.GetValue();
            VitSkillCheck(vitStat);
        }
        else if (stat == "AGI")
        {
            int agiStat = playerStats.agi.GetValue();
            AgiSkillCheck(agiStat);
        }
        else if (stat == "DEX")
        {
            int dexStat = playerStats.dex.GetValue();
            DexSkillCheck(dexStat);
        }
        else if (stat == "LUK")
        {
            int lukStat = playerStats.luk.GetValue();
            LukSkillCheck(lukStat);
        }

    }

    private void StrSkillCheck(int stat)
    {
        //STR
        if (stat >= 5 && stat < 10)
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
        else if (stat >= 10 && stat < 15)
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
        else if (stat >= 15 && stat < 20)
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
        else if (stat >= 20)
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

    private void VitSkillCheck(int stat)
    {
        //VIT
        if (stat >= 5 && stat < 10)
        {
            VitSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.VitSkill1);
            VitSkill2.InActive();
            uiSkill.SetSkillInActive(uiSkill.VitSkill2);
            VitSkill3.InActive();
            uiSkill.SetSkillInActive(uiSkill.VitSkill3);
            VitSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.VitSkill4);
        }
        else if (stat >= 10 && stat < 15)
        {
            VitSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.VitSkill1);
            VitSkill2.Active();
            uiSkill.SetSkillActive(uiSkill.VitSkill2);
            VitSkill3.InActive();
            uiSkill.SetSkillInActive(uiSkill.VitSkill3);
            VitSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.VitSkill4);
        }
        else if (stat >= 15 && stat < 20)
        {
            VitSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.VitSkill1);
            VitSkill2.Active();
            uiSkill.SetSkillActive(uiSkill.VitSkill2);
            VitSkill3.Active();
            uiSkill.SetSkillActive(uiSkill.VitSkill3);
            VitSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.VitSkill4);
        }
        else if (stat >= 20)
        {
            VitSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.VitSkill1);
            VitSkill2.Active();
            uiSkill.SetSkillActive(uiSkill.VitSkill2);
            VitSkill3.Active();
            uiSkill.SetSkillActive(uiSkill.VitSkill3);
            VitSkill4.Active();
            uiSkill.SetSkillActive(uiSkill.VitSkill4);
        }
        else
        {
            VitSkill1.InActive();
            uiSkill.SetSkillInActive(uiSkill.VitSkill1);
            VitSkill2.InActive();
            uiSkill.SetSkillInActive(uiSkill.VitSkill2);
            VitSkill3.InActive();
            uiSkill.SetSkillInActive(uiSkill.VitSkill3);
            VitSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.VitSkill4);
        }
    }

    private void AgiSkillCheck(int stat)
    {
        //AGI
        if (stat >= 5 && stat < 10)
        {
            AgiSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.AgiSkill1);
            AgiSkill2.InActive();
            uiSkill.SetSkillInActive(uiSkill.AgiSkill2);
            AgiSkill3.InActive();
            uiSkill.SetSkillInActive(uiSkill.AgiSkill3);
            AgiSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.AgiSkill4);
        }
        else if (stat >= 10 && stat < 15)
        {
            AgiSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.AgiSkill1);
            AgiSkill2.Active();
            uiSkill.SetSkillActive(uiSkill.AgiSkill2);
            AgiSkill3.InActive();
            uiSkill.SetSkillInActive(uiSkill.AgiSkill3);
            AgiSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.AgiSkill4);
        }
        else if (stat >= 15 && stat < 20)
        {
            AgiSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.AgiSkill1);
            AgiSkill2.Active();
            uiSkill.SetSkillActive(uiSkill.AgiSkill2);
            AgiSkill3.Active();
            uiSkill.SetSkillActive(uiSkill.AgiSkill3);
            AgiSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.AgiSkill4);
        }
        else if (stat >= 20)
        {
            AgiSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.AgiSkill1);
            AgiSkill2.Active();
            uiSkill.SetSkillActive(uiSkill.AgiSkill2);
            AgiSkill3.Active();
            uiSkill.SetSkillActive(uiSkill.AgiSkill3);
            AgiSkill4.Active();
            uiSkill.SetSkillActive(uiSkill.AgiSkill4);
        }
        else
        {
            AgiSkill1.InActive();
            uiSkill.SetSkillInActive(uiSkill.AgiSkill1);
            AgiSkill2.InActive();
            uiSkill.SetSkillInActive(uiSkill.AgiSkill2);
            AgiSkill3.InActive();
            uiSkill.SetSkillInActive(uiSkill.AgiSkill3);
            AgiSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.AgiSkill4);
        }
    }

    private void DexSkillCheck(int stat)
    {
        //DEX
        if (stat >= 5 && stat < 10)
        {
            DexSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.DexSkill1);
            DexSkill2.InActive();
            uiSkill.SetSkillInActive(uiSkill.DexSkill2);
            DexSkill3.InActive();
            uiSkill.SetSkillInActive(uiSkill.DexSkill3);
            DexSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.DexSkill4);
        }
        else if (stat >= 10 && stat < 15)
        {
            DexSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.DexSkill1);
            DexSkill2.Active();
            uiSkill.SetSkillActive(uiSkill.DexSkill2);
            DexSkill3.InActive();
            uiSkill.SetSkillInActive(uiSkill.DexSkill3);
            DexSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.DexSkill4);
        }
        else if (stat >= 15 && stat < 20)
        {
            DexSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.DexSkill1);
            DexSkill2.Active();
            uiSkill.SetSkillActive(uiSkill.DexSkill2);
            DexSkill3.Active();
            uiSkill.SetSkillActive(uiSkill.DexSkill3);
            DexSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.DexSkill4);
        }
        else if (stat >= 20)
        {
            DexSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.DexSkill1);
            DexSkill2.Active();
            uiSkill.SetSkillActive(uiSkill.DexSkill2);
            DexSkill3.Active();
            uiSkill.SetSkillActive(uiSkill.DexSkill3);
            DexSkill4.Active();
            uiSkill.SetSkillActive(uiSkill.DexSkill4);
        }
        else
        {
            DexSkill1.InActive();
            uiSkill.SetSkillInActive(uiSkill.DexSkill1);
            DexSkill2.InActive();
            uiSkill.SetSkillInActive(uiSkill.DexSkill2);
            DexSkill3.InActive();
            uiSkill.SetSkillInActive(uiSkill.DexSkill3);
            DexSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.DexSkill4);
        }
    }

    private void LukSkillCheck(int stat)
    {
        //Luk
        if (stat >= 5 && stat < 10)
        {
            LukSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.LukSkill1);
            LukSkill2.InActive();
            uiSkill.SetSkillInActive(uiSkill.LukSkill2);
            LukSkill3.InActive();
            uiSkill.SetSkillInActive(uiSkill.LukSkill3);
            LukSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.LukSkill4);
        }
        else if (stat >= 10 && stat < 15)
        {
            LukSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.LukSkill1);
            LukSkill2.Active();
            uiSkill.SetSkillActive(uiSkill.LukSkill2);
            LukSkill3.InActive();
            uiSkill.SetSkillInActive(uiSkill.LukSkill3);
            LukSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.LukSkill4);
        }
        else if (stat >= 15 && stat < 20)
        {
            LukSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.LukSkill1);
            LukSkill2.Active();
            uiSkill.SetSkillActive(uiSkill.LukSkill2);
            LukSkill3.Active();
            uiSkill.SetSkillActive(uiSkill.LukSkill3);
            LukSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.LukSkill4);
        }
        else if (stat >= 20)
        {
            LukSkill1.Active();
            uiSkill.SetSkillActive(uiSkill.LukSkill1);
            LukSkill2.Active();
            uiSkill.SetSkillActive(uiSkill.LukSkill2);
            LukSkill3.Active();
            uiSkill.SetSkillActive(uiSkill.LukSkill3);
            LukSkill4.Active();
            uiSkill.SetSkillActive(uiSkill.LukSkill4);
        }
        else
        {
            LukSkill1.InActive();
            uiSkill.SetSkillInActive(uiSkill.LukSkill1);
            LukSkill2.InActive();
            uiSkill.SetSkillInActive(uiSkill.LukSkill2);
            LukSkill3.InActive();
            uiSkill.SetSkillInActive(uiSkill.LukSkill3);
            LukSkill4.InActive();
            uiSkill.SetSkillInActive(uiSkill.LukSkill4);
        }
    }
}
