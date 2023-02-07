using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{

    public EXPmanager expManager;
    public int currentStatPoint,statPoint;
    public int usedStatPoint;
    public int currentPlayerLevel;
    private UI_Status playerStat;
    public SkillManager skillManager;

    public int skillAtkBonus, skillHPBonus, skillCriRateBonus, skillCriDamageBonus, skillMovespeedBonus, skillDropRateBonus;

    //skill Stat Mod
    public float hpMultiplyer;

    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
        statPoint = expManager.statPoint;
        currentPlayerLevel = expManager.level;
        currentStatPoint = statPoint - usedStatPoint;

       /* playerStat = GameObject.Find("GameManager").GetComponent<UI_Status>();
        playerStat.charaStat = this;*/
    }

    private void Awake()
    {
       /* playerStat = GameObject.Find("GameManager").GetComponent<UI_Status>();
        playerStat.charaStat = this;*/

        //skillManager.gameObject.GetComponent<SkillManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            expManager.AddEXP(200);
        }

        statPoint = expManager.statPoint;
        currentPlayerLevel = expManager.level;
        currentStatPoint = statPoint - usedStatPoint;
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
            usedStatPoint++;
            CheckStatusPoint();
            skillManager.CheckSkillActive(stat);
        }
    }
    public void ReduceStat(string stat)
    {
        if (statPoint < maxStatPoint && currentStatPoint+usedStatPoint <= statPoint)
        {
            if (stat == "STR")
            {
                if(str.GetValue() > 0)
                {
                    str.RemoveModifier(1);
                    currentStatPoint += 1;
                    usedStatPoint -= 1;
                }              
            }
            else if (stat == "VIT")
            {
                if (vit.GetValue() > 0)
                {
                    vit.RemoveModifier(1);
                    currentStatPoint += 1;
                    usedStatPoint -= 1;
                }
            }
            else if (stat == "AGI")
            {
                if (agi.GetValue() > 0)
                {
                    agi.RemoveModifier(1);
                    currentStatPoint += 1;
                    usedStatPoint -= 1;
                }
            }
            else if (stat == "DEX")
            {
                if (dex.GetValue() > 0)
                {
                    dex.RemoveModifier(1);
                    currentStatPoint += 1;
                    usedStatPoint -= 1;
                }
            }
            else if (stat == "LUK")
            {
                if (luk.GetValue() > 0)
                {
                    luk.RemoveModifier(1);
                    currentStatPoint += 1;
                    usedStatPoint -= 1;
                }
            }
            
            if(usedStatPoint < 0)
            {
                usedStatPoint = 0;
                currentStatPoint -= 1;
            }else if (usedStatPoint+ currentStatPoint != statPoint)
            {
                currentStatPoint -= 1;
            }
            skillManager.CheckSkillActive(stat);
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
        maxHealth = 100 + (vit.GetValue() * 10) + skillHPBonus;
        attack.SetBaseValue(str.GetValue() * 3 + skillAtkBonus) ;
        moveSpeed.SetBaseValue(agi.GetValue() * 2 + skillMovespeedBonus);
        critRate.SetBaseValue((dex.GetValue() * 1)+(luk.GetValue()*2) + skillCriRateBonus);
        critDamage.SetBaseValue(dex.GetValue() * 2 +skillCriDamageBonus);
        dropRate.SetBaseValue(luk.GetValue() * 2 + skillDropRateBonus);
    }
    }
