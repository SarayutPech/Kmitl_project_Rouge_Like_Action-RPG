using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
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
}
