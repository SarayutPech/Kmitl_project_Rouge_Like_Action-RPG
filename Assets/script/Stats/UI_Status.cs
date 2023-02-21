using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Status : MonoBehaviour
{
    [SerializeField]
    public PlayerStats charaStat;
    public GameObject statusUI;
    public GameObject upstatusUI;

    public TextMeshProUGUI remainPoint;
    //------Status-----
    public TextMeshProUGUI str,vit,agi,dex,luk;
    public TextMeshProUGUI str_UI,vit_UI,agi_UI,dex_UI,luk_UI;
    //------Parameter----
    public TextMeshProUGUI level, maxHp, atk, criRate, criDmg, moveSpd, dropRate;

    //------Button Up Status----
    public Button plusStr_btn, plusVit_btn, plusAgi_Btn, plusDex_Btn, plusLuk_Btn;
    //------Button Up Status----
    public Button downStr_btn, downVit_btn, downAgi_Btn, downDex_Btn, downLuk_Btn;

    public void Start()
    {
        //UpdateParameterUI();
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
        charaStat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();


    }

    void Awake()
    {


        //------Up Status Button----
        plusStr_btn.onClick.AddListener(delegate { UpStatus("STR"); });
        plusVit_btn.onClick.AddListener(delegate { UpStatus("VIT"); });
        plusAgi_Btn.onClick.AddListener(delegate { UpStatus("AGI"); });
        plusDex_Btn.onClick.AddListener(delegate { UpStatus("DEX"); });
        plusLuk_Btn.onClick.AddListener(delegate { UpStatus("LUK"); });
        //------Down Status Button
        downStr_btn.onClick.AddListener(delegate { DownStatus("STR"); });
        downVit_btn.onClick.AddListener(delegate { DownStatus("VIT"); });
        downAgi_Btn.onClick.AddListener(delegate { DownStatus("AGI"); });
        downDex_Btn.onClick.AddListener(delegate { DownStatus("DEX"); });
        downLuk_Btn.onClick.AddListener(delegate { DownStatus("LUK"); });

        //playerObj = GameObject.Find("Player_witch(Clone)");
        //Debug.Log(playerObj.name);
        //charaStat = playerObj.GetComponent<PlayerStats>();
    }


    public void UpdateParameterUI()
    {
        maxHp.text = charaStat.maxHealth.ToString();
        atk.text = charaStat.attack.GetValue().ToString();
        criRate.text = charaStat.critRate.GetValue().ToString();
        criDmg.text = charaStat.critDamage.GetValue().ToString();
        moveSpd.text = charaStat.moveSpeed.GetValue().ToString();
        dropRate.text = charaStat.dropRate.GetValue().ToString();

        level.text = charaStat.currentPlayerLevel.ToString();

        str.text = charaStat.str.GetValue().ToString();
        vit.text = charaStat.vit.GetValue().ToString();
        agi.text = charaStat.agi.GetValue().ToString();
        dex.text = charaStat.dex.GetValue().ToString();
        luk.text = charaStat.luk.GetValue().ToString();

        remainPoint.text = charaStat.currentStatPoint.ToString();
    }
    public void UpdateStatusUI()
    {
        str_UI.text = charaStat.str.GetValue().ToString();
        vit_UI.text = charaStat.vit.GetValue().ToString();
        agi_UI.text = charaStat.agi.GetValue().ToString();
        dex_UI.text = charaStat.dex.GetValue().ToString();
        luk_UI.text = charaStat.luk.GetValue().ToString();
    }

    public void Update()
    {
        
       // Debug.Log("Update Parameter UI");

        if (Input.GetButtonDown("Inventory"))
        {
           // Debug.Log("Inventory Active");
            statusUI.SetActive(!statusUI.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {

            upstatusUI.SetActive(!upstatusUI.activeSelf);
        }
        UpdateParameterUI();
        //UpdateStatusUI();
    }
    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        charaStat.CalculateBaseStat();
        UpdateParameterUI();
        UpdateStatusUI();

    }
    public void UpStatus(string stats)
    {
        charaStat.UpgradeStat(stats);
        charaStat.CalculateBaseStat();
        UpdateStatusUI();
       // UpdateParameterUI();
    }

    public void DownStatus(string stats)
    {
        charaStat.ReduceStat(stats);
        charaStat.CalculateBaseStat();
        UpdateStatusUI();
        //UpdateParameterUI();
    }

}
