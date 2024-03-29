using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Equipment" , menuName = "Inventory/Equipment")]
public class Equipment : Item
{

    public ItemType equipSlot;

    [SerializeField]
    public Vector2 forceWeapon;
    public Vector2 hitboxWeapon;

    

    //public bool isEquip = false; 

    public override void Use()
    {
        base.Use();
        // Equip item
        
        EquipmentManager.instance.Equip(this);
        //isEquip = true;
        // remove from inventory
        RemoveFromInventory();
             
    }

    public override void Attack()
    {
        base.Attack();
    }




}

