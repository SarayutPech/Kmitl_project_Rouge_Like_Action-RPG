using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Result_UI : MonoBehaviour
{

    public TextMeshProUGUI item_PickUp_Text, enemy_Defeated_Text, boss_Defeated_text, floor_Reach_Text , convert_EXP_Text , player_Level;
    public EXP_Bar expBar;
    ResultScreen result;
    //public GameObject gameResult_UI;

    public Button confirmBtn;
    //GameObject gameSystem;
    private void Start()
    {
        confirmBtn.onClick.AddListener(RestartGame);

        //gameSystem  = GameObject.FindGameObjectWithTag("GameSystem");
        
        GameOver();

        // 
    }




    public void UpdateResultUI()
    {
        result = GameObject.FindGameObjectWithTag("GameSystem").GetComponentInChildren<ResultScreen>();

        item_PickUp_Text.text = result.item_pickup.ToString();
        enemy_Defeated_Text.text = result.enemy_defeated.ToString();
        boss_Defeated_text.text = result.boss_defeated.ToString();
        floor_Reach_Text.text = result.floor_clear.ToString();
        convert_EXP_Text.text = result.Calculate_EXP_Gain().ToString();

        EXPmanager xpManager = GameObject.FindGameObjectWithTag("Player").GetComponent<EXPmanager>();
        expBar = GameObject.FindGameObjectWithTag("EXP_Bar").GetComponent<EXP_Bar>();
        xpManager.AddEXP(result.Calculate_EXP_Gain());

        player_Level.text = xpManager.level.ToString();

        

        expBar.SetEXP(xpManager.currentEXP);
        expBar.SetMaxEXP(xpManager.targetEXP);
        expBar.SetEXP(xpManager.currentEXP);
        expBar.SetMaxEXP(xpManager.targetEXP);
        expBar.setTextEXP(xpManager.currentEXP, xpManager.targetEXP);


    }

    public void GameOver()
    {
        
        //gameResult_UI.SetActive(true);
        
        UpdateResultUI();

        //Save Character Stat
        SaveSystem saveSystem = GameObject.FindGameObjectWithTag("GameSystem").GetComponentInChildren<SaveSystem>();
        saveSystem.Save();

       
    }

    public void RestartGame()
    {
        //Destroy Player Object
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        

        //EquipmentManager equipmentManager = GameObject.FindGameObjectWithTag("GameSystem").GetComponentInChildren<EquipmentManager>();
        //Inventory inventory = GetComponentInParent<Inventory>();
        
        GameObject gameSystem = GameObject.FindGameObjectWithTag("GameSystem");

        
        //equipmentManager.UnequipAll();
        //inventory.RemoveAllItem();
        Destroy(player);

        //gameResult_UI.SetActive(false);
        Destroy(gameSystem);
        // player.transform.position = new Vector3(24f, 1.12f, -3f);
        
        SceneManager.LoadScene("Lobby_Town");
        
    }

}
