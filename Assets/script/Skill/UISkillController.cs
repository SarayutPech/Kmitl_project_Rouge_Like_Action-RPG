using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UISkillController : MonoBehaviour
{

    public Image StrSkill1, StrSkill2, StrSkill3, StrSkill4;
    public Image VitSkill1, VitSkill2, VitSkill3, VitSkill4;
    public Image AgiSkill1, AgiSkill2, AgiSkill3, AgiSkill4;
    public Image DexSkill1, DexSkill2, DexSkill3, DexSkill4;
    public Image LukSkill1, LukSkill2, LukSkill3, LukSkill4;
    // Start is called before the first frame update
    private void Start()
    {
        SetSkillInActive(StrSkill1);
        SetSkillInActive(StrSkill2);
        SetSkillInActive(StrSkill3);
        SetSkillInActive(StrSkill4);

        SetSkillInActive(VitSkill1);
        SetSkillInActive(VitSkill2);
        SetSkillInActive(VitSkill3);
        SetSkillInActive(VitSkill4);

        SetSkillInActive(AgiSkill1);
        SetSkillInActive(AgiSkill2);
        SetSkillInActive(AgiSkill3);
        SetSkillInActive(AgiSkill4);

        SetSkillInActive(DexSkill1);
        SetSkillInActive(DexSkill2);
        SetSkillInActive(DexSkill3);
        SetSkillInActive(DexSkill4);

        SetSkillInActive(LukSkill1);
        SetSkillInActive(LukSkill2);
        SetSkillInActive(LukSkill3);
        SetSkillInActive(LukSkill4);
    }

    public void SetSkillActive(Image skill)
    {
        skill.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void SetSkillInActive(Image skill)
    {
        skill.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
    }
}
