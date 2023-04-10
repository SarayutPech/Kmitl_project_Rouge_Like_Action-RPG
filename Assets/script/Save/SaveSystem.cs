using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{


    public void Save()
    {
        SelectedSave saveSlot = GameObject.FindGameObjectWithTag("SaveData").GetComponent<SelectedSave>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerStats playerStat = player.GetComponent<PlayerStats>();
        EXPmanager playerExp = player.GetComponent<EXPmanager>();

        SaveObject saveObject = new SaveObject
        {
            playerLevel = playerExp.level,
            statPoint = playerExp.statPoint,
            currentExp = playerExp.currentEXP,
            targetExp = playerExp.targetEXP,
            str_Stat = playerStat.str.GetValue(),
            vit_Stat = playerStat.vit.GetValue(),
            agi_Stat = playerStat.agi.GetValue(),
            dex_Stat = playerStat.dex.GetValue(),
            luk_Stat = playerStat.luk.GetValue()
        };

        string saveJson = JsonUtility.ToJson(saveObject);

        // save using PlayerPerfs instead of txt file
        PlayerPrefs.SetString("saveData" + saveSlot.getSaveSelected(), saveJson);

       // File.WriteAllText(Application.dataPath + "/Save/saveData"+ saveSlot.getSaveSelected() + ".txt", saveJson);
    }

    public void Load()
    {
        SelectedSave saveSlot = GameObject.FindGameObjectWithTag("SaveData").GetComponent<SelectedSave>();


        //if (File.Exists(Application.dataPath + "/Save/saveData"+ saveSlot.getSaveSelected()+".txt"))
        if (PlayerPrefs.HasKey("saveData" + saveSlot.getSaveSelected()))
        {
            //string saveString = File.ReadAllText(Application.dataPath + "/Save/saveData"+ saveSlot.getSaveSelected()+".txt");
            string saveString = PlayerPrefs.GetString("saveData" + saveSlot.getSaveSelected());
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            LoadCharacterStat(saveObject);
            Debug.Log("Save Loaded. !");

        }
        else
        {
            Debug.Log("Cannot Load Save.");
        }
    }

    private void LoadCharacterStat(SaveObject saveObject)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerStats playerStat = player.GetComponent<PlayerStats>();
        EXPmanager playerExp = player.GetComponent<EXPmanager>();
        SkillManager playerSkill = player.GetComponent<SkillManager>();
        UI_Status ui_Status = GetComponentInParent<UI_Status>();

        playerExp.level = saveObject.playerLevel;
        playerExp.statPoint = saveObject.statPoint;
        playerExp.targetEXP = saveObject.targetExp;
        playerExp.currentEXP = saveObject.currentExp;

        Debug.Log("Level : " + saveObject.playerLevel + " StatPoint : "+ saveObject.statPoint);
        
        // Load Stat 
        if (saveObject.str_Stat > 0) // STR
        {
            //playerStat.str.SetBaseValue(saveObject.str_Stat);
            for (int i = 1; i <= saveObject.str_Stat; i++)
            {
                playerStat.str.AddModifier(1);
                playerStat.currentStatPoint -= 1;
                playerStat.usedStatPoint++;
                playerStat.CheckStatusPoint();
                playerSkill.CheckSkillActive("STR");
                //playerStat.UpgradeStat("STR");
                Debug.Log("Load STR :" + saveObject.str_Stat);
            }
            //playerSkill.StrSkillCheck(saveObject.str_Stat);
        }
        if (saveObject.vit_Stat > 0) // VIT
        {
            for (int i = 1; i <= saveObject.vit_Stat; i++)
            {
                playerStat.vit.AddModifier(1);
                playerStat.currentStatPoint -= 1;
                playerStat.usedStatPoint++;
                playerStat.CheckStatusPoint();
                playerSkill.CheckSkillActive("VIT");
                //playerStat.UpgradeStat("VIT");
                Debug.Log("Load VIT :" + saveObject.vit_Stat);
            }
        }
        if (saveObject.agi_Stat > 0) // AGI
        {
            for (int i = 1; i <= saveObject.agi_Stat; i++)
            {
                playerStat.agi.AddModifier(1);
                playerStat.currentStatPoint -= 1;
                playerStat.usedStatPoint++;
                playerStat.CheckStatusPoint();
                playerSkill.CheckSkillActive("AGI");
                //playerStat.UpgradeStat("AGI");
                Debug.Log("Load AGI :" + saveObject.agi_Stat);
            }
        }
        if (saveObject.dex_Stat > 0)  // DEX
        {
            for (int i = 1; i <= saveObject.dex_Stat; i++)
            {
                playerStat.dex.AddModifier(1);
                playerStat.currentStatPoint -= 1;
                playerStat.usedStatPoint++;
                playerStat.CheckStatusPoint();
                playerSkill.CheckSkillActive("DEX");
                // playerStat.UpgradeStat("DEX");
                Debug.Log("Load DEX :" + saveObject.dex_Stat);
            }
        }
        if (saveObject.luk_Stat > 0) // LUK
        {
            for (int i = 1; i <= saveObject.luk_Stat; i++)
            {
                playerStat.luk.AddModifier(1);
                playerStat.currentStatPoint -= 1;
                playerStat.usedStatPoint++;
                playerStat.CheckStatusPoint();
                playerSkill.CheckSkillActive("LUK");
                //playerStat.UpgradeStat("LUK");
                Debug.Log("Load LUK :" + saveObject.luk_Stat);
            }
        }

        try
        {
            playerStat.CalculateBaseStat();
            ui_Status.UpdateParameterUI();
            ui_Status.UpdateStatusUI();
        }
        catch { Debug.Log("Cannot Update UI"); }
    }

    private class SaveObject
    {
        public int playerLevel;
        public int statPoint;
        public int currentExp, targetExp;
        public int str_Stat, vit_Stat, agi_Stat, dex_Stat, luk_Stat;
    }
}
