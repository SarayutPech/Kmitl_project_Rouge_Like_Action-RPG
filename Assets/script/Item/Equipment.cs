using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Equipment" , menuName = "Inventory/Equipment")]
public class Equipment : Item
{

    public EquipmentSlot equipSlot;

    public int attackModifier;
    public int healthModifier;

    public override void Use()
    {
        base.Use();
        // Equip item
        EquipmentManager.instance.Equip(this);

        // remove from inventory
        RemoveFromInventory();
    }

}

public enum EquipmentSlot { WeaponCard , Accessory}
