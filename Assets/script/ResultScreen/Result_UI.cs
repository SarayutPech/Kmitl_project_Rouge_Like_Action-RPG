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
    public ResultScreen result;
    public GameObject gameResult_UI;

    public Button confirmBtn;

    private void Start()
    {
        confirmBtn.onClick.AddListener(RestartGame);
    }




    public void UpdateResultUI()
    {
        expBar = GameObject.Find("exp_Bar").GetComponent<EXP_Bar>();

        item_PickUp_Text.text = result.item_pickup.ToString();
        enemy_Defeated_Text.text = result.enemy_defeated.ToString();
        boss_Defeated_text.text = result.boss_defeated.ToString();
        floor_Reach_Text.text = result.floor_clear.ToString();
        convert_EXP_Text.text = result.Calculate_EXP_Gain().ToString();

        EXPmanager xpManager = GameObject.FindGameObjectWithTag("Player").GetComponent<EXPmanager>();

        xpManager.AddEXP(result.Calculate_EXP_Gain());

        player_Level.text = xpManager.level.ToString();

        expBar.SetEXP(xpManager.currentEXP);
        expBar.SetMaxEXP(xpManager.targetEXP);
        expBar.setTextEXP(xpManager.currentEXP, xpManager.targetEXP);


    }

    public void GameOver()
    {
        gameResult_UI.SetActive(true);
        UpdateResultUI();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Lobby_Town");
        gameResult_UI.SetActive(false);
    }

}
