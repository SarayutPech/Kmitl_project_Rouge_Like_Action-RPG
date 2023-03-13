using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveSelect_Btn : MonoBehaviour
{
    [SerializeField]
    Button SaveSlot1, SaveSlot2, SaveSlot3;
    SelectedSave saveSelect;

    // Start is called before the first frame update
    void Start()
    {
        saveSelect = GameObject.FindGameObjectWithTag("SaveData").GetComponent<SelectedSave>();

        SaveSlot1.onClick.AddListener(SelectSlot1);
        SaveSlot2.onClick.AddListener(SelectSlot2);
        SaveSlot3.onClick.AddListener(SelectSlot3);
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
}
