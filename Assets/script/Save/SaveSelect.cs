using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSelect : MonoBehaviour
{
    [SerializeField]
    GameObject slot1, slot2, slot3;
    SaveSlot saveSlot1, saveSlot2, saveSlot3;
    // Start is called before the first frame update
    void Start()
    {
        saveSlot1 = slot1.GetComponent<SaveSlot>();
        saveSlot2 = slot2.GetComponent<SaveSlot>();
        saveSlot3 = slot3.GetComponent<SaveSlot>();

        LoadSaveSlotData();
    }

    private void LoadSaveSlotData()
    {
        //Check Save Slot1
        if (File.Exists(Application.dataPath + "/Save/saveData_Slot1.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/Save/saveData_Slot1.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            saveSlot1.setShowData(saveObject.playerLevel);
            saveSlot1.ShowData();


        }
        else
        {
            saveSlot1.ShowEmpty();
        }

        //Check Save Slot2
        if (File.Exists(Application.dataPath + "/Save/saveData_Slot2.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/Save/saveData_Slot2.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            saveSlot2.setShowData(saveObject.playerLevel);
            saveSlot2.ShowData();

        }
        else
        {
            saveSlot2.ShowEmpty();
        }

        //Check Save Slot3
        if (File.Exists(Application.dataPath + "/Save/saveData_Slot3.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/Save/saveData_Slot3.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            saveSlot3.setShowData(saveObject.playerLevel);
            saveSlot3.ShowData();

        }
        else
        {
            saveSlot3.ShowEmpty();
        }
    }
    private class SaveObject
    {
        public int playerLevel;
        public int statPoint;
        public int currentExp, targetExp;
        public int str_Stat, vit_Stat, agi_Stat, dex_Stat, luk_Stat;
    }
}


