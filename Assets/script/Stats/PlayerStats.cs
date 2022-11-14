using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public int currentStatPoint = 5;
    public int currentPlayerLevel = 5;
    private UI_Status playerStat;
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    private void Awake()
    {
        playerStat = GameObject.Find("GameManager").GetComponent<UI_Status>();
        playerStat.charaStat = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
           
        }
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            attack.AddModifier(newItem.attack_Modifier);
            critRate.AddModifier(newItem.critRate_Modifier);
            critDamage.AddModifier(newItem.critDamage_Modifier);
            moveSpeed.AddModifier(newItem.moveSpeed_Modifier);
            dropRate.AddModifier(newItem.dropRate_Modifier);
            hp.AddModifier(newItem.health_Modifier);
        }
        
        if(oldItem != null)
        {       
            attack.RemoveModifier(oldItem.attack_Modifier);
            critRate.RemoveModifier(oldItem.critRate_Modifier);
            critDamage.RemoveModifier(oldItem.critDamage_Modifier);
            moveSpeed.RemoveModifier(oldItem.moveSpeed_Modifier);
            dropRate.RemoveModifier(oldItem.dropRate_Modifier);
            hp.RemoveModifier(oldItem.health_Modifier);
        }
    }

    public void UpgradeStat(string stat)
    {
        if(currentStatPoint > 0)
        {
            if(stat == "STR")
            {
                str.AddModifier(1);

            }else if(stat == "VIT")
            {
                vit.AddModifier(1);
            }
            else if (stat == "AGI")
            {
                agi.AddModifier(1);
            }
            else if (stat == "DEX")
            {
                dex.AddModifier(1);
            }
            else if (stat == "LUK")
            {
                luk.AddModifier(1);
            }

            currentStatPoint -= 1;
            CheckStatusPoint();
        }
    }
    public void ReduceStat(string stat)
    {
        if (currentStatPoint < maxStatPoint && currentStatPoint < currentPlayerLevel)
        {
            if (stat == "STR")
            {
                if(str.GetValue() > 0)
                {
                    str.RemoveModifier(1);
                    currentStatPoint += 1;
                }              
            }
            else if (stat == "VIT")
            {
                if (vit.GetValue() > 0)
                {
                    vit.RemoveModifier(1);
                    currentStatPoint += 1;
                }
            }
            else if (stat == "AGI")
            {
                if (agi.GetValue() > 0)
                {
                    agi.RemoveModifier(1);
                    currentStatPoint += 1;
                }
            }
            else if (stat == "DEX")
            {
                if (dex.GetValue() > 0)
                {
                    dex.RemoveModifier(1);
                    currentStatPoint += 1;
                }
            }
            else if (stat == "LUK")
            {
                if (luk.GetValue() > 0)
                {
                    luk.RemoveModifier(1);
                    currentStatPoint += 1;
                }
            }

            
        }
    }

    private bool CheckStatusPoint()
    {
        int allstatus = str.GetValue() + vit.GetValue() + agi.GetValue() + dex.GetValue() + luk.GetValue()+currentStatPoint;
        Debug.Log("all point : "+ allstatus.ToString());
        if(allstatus == currentPlayerLevel)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    public void CalculateBaseStat()
    {
        maxHealth = 100 + (vit.GetValue() * 10);
        attack.SetBaseValue(str.GetValue() * 3);
        moveSpeed.SetBaseValue(agi.GetValue() * 2);
        critRate.SetBaseValue((dex.GetValue() * 1)+(luk.GetValue()*2));
        critDamage.SetBaseValue(dex.GetValue() * 2);
        dropRate.SetBaseValue(luk.GetValue() * 2);
    }
    }
