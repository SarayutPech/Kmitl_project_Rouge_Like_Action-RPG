using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveSelect_Btn : MonoBehaviour
{
    [SerializeField]
    Button SaveSlot1, SaveSlot2, SaveSlot3;
    [SerializeField]
    Button deleteSlot1, deleteSlot2, deleteSlot3 , backBtn;
    SelectedSave saveSelect;
    GameObject saveData;
    SaveSelect saveUI;

    // Start is called before the first frame update
    void Start()
    {
        saveData = GameObject.FindGameObjectWithTag("SaveData");
        saveSelect = saveData.GetComponent<SelectedSave>();
        saveUI = GetComponentInParent<SaveSelect>();

        SaveSlot1.onClick.AddListener(SelectSlot1);
        SaveSlot2.onClick.AddListener(SelectSlot2);
        SaveSlot3.onClick.AddListener(SelectSlot3);

        deleteSlot1.onClick.AddListener(DeleteSlot1);
        deleteSlot2.onClick.AddListener(DeleteSlot2);
        deleteSlot3.onClick.AddListener(DeleteSlot3);

        backBtn.onClick.AddListener(BackToTitle);
    }

    private void SelectSlot1()
    {
        saveSelect.setSaveSelected(1);
        
        GoToLobby();
    }
    private void SelectSlot2()
    {
        saveSelect.setSaveSelected(2);
        GoToLobby();
    }

    private void SelectSlot3()
    {
        saveSelect.setSaveSelected(3);
        GoToLobby();
    }

    private void GoToLobby()
    {
        SceneManager.LoadScene("Lobby_Town");
    }

    private void BackToTitle()
    {
        Destroy(saveData);
        SceneManager.LoadScene("Title_Screen");
        
    }

    private void DeleteSlot1()
    {
        if (PlayerPrefs.HasKey("saveData_Slot1"))
        {
            PlayerPrefs.DeleteKey("saveData_Slot1");           
            saveUI.LoadSaveSlotData();
        }
        /*if(File.Exists(Application.dataPath + "/Save/saveData_Slot1.txt")){
            File.Delete(Application.dataPath + "/Save/saveData_Slot1.txt");
            saveUI.LoadSaveSlotData();
        }*/

    }

    private void DeleteSlot2()
    {
        if (PlayerPrefs.HasKey("saveData_Slot2"))
        {
            PlayerPrefs.DeleteKey("saveData_Slot2");
            saveUI.LoadSaveSlotData();
        }
        /*if (File.Exists(Application.dataPath + "/Save/saveData_Slot2.txt"))
        {
            File.Delete(Application.dataPath + "/Save/saveData_Slot2.txt");
            saveUI.LoadSaveSlotData();
        }*/
    }

    private void DeleteSlot3()
    {
        if (PlayerPrefs.HasKey("saveData_Slot3"))
        {
            PlayerPrefs.DeleteKey("saveData_Slot3");
            saveUI.LoadSaveSlotData();
        }
        /*if (File.Exists(Application.dataPath + "/Save/saveData_Slot3.txt"))
        {
            File.Delete(Application.dataPath + "/Save/saveData_Slot3.txt");
            saveUI.LoadSaveSlotData();
        }*/
    }

   
}
