using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton
    public static EquipmentManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Equipment[] currentEquipCard;
    public Equipment[] currentEquipAccessory;


    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    public delegate void OnEquipChanged();
    public OnEquipChanged onEquipCallback;


    EquipmentCardSlot equipCard;
    EquipmentAccSlot equipAcc;

    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;

        currentEquipCard = new Equipment[5]; // Max equipment slot of Weapon Card
        currentEquipAccessory = new Equipment[4]; // Max equipment slot of Accessory
    }

    public void Equip (Equipment newItem)
    {
        if(newItem.equipSlot == EquipmentSlot.WeaponCard)
        {
            int slotIndex = (int)CheckSlotIndex(currentEquipCard); // Check and get slot index

            Equipment oldItem = CheckItemInSlot(currentEquipCard[slotIndex]); // Check Equipment Slot is empty or not 
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(newItem, oldItem);
                
            }
            //equipCard.EquipItem(newItem);
            
            currentEquipCard[slotIndex] = newItem; // Equip Item

            if (onEquipCallback != null)
            {
                onEquipCallback.Invoke();
            }
            

        }
        else if(newItem.equipSlot == EquipmentSlot.Accessory)
        {
            int slotIndex = (int)CheckSlotIndex(currentEquipAccessory);

            Equipment oldItem = CheckItemInSlot(currentEquipAccessory[slotIndex]);
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(newItem, oldItem);
                onEquipCallback.Invoke();
            }
            //equipAcc.EquipItem(newItem);
            
            currentEquipAccessory[slotIndex] = newItem;

            if (onEquipCallback != null)
            {
                onEquipCallback.Invoke();
            }
        }
    }


    public void Unequip (Equipment[] equipmentSlot ,int slotIndex)
    {
        if(equipmentSlot[slotIndex] != null)
        {
            Equipment oldItem = equipmentSlot[slotIndex];
            inventory.AddItem(oldItem);

            equipmentSlot[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
                onEquipCallback.Invoke();
            }
        }
    }

    public void UnequipAll()
    {
        for(int i = 0; i < currentEquipCard.Length; i++) // Unequip all Card Weapon
        {
            Unequip(currentEquipCard, i);      
        }
        for (int i = 0; i < currentEquipAccessory.Length; i++) // Unequip all Accessory
        {
            Unequip(currentEquipAccessory, i);
        }
        onEquipCallback.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }

    private int CheckSlotIndex(Equipment[] equipmentSlot)
    {
        for(int i = 0; i < equipmentSlot.Length ; i++) // loop to find empty slot index
        {
            if(equipmentSlot[i] == null)
            {
                return i; // return slot index that empty
            }
        }
        return 0; // if slot are full replace at index 0
        
    }

    private Equipment CheckItemInSlot(Equipment equipItem)
    {
        Equipment oldItem = null; // temp variable for store equipped item
        if(equipItem != null)
        {
            oldItem = equipItem;
            inventory.AddItem(oldItem);

            return oldItem;
        }
        else { 
            return null;
        }

        
    }

    public int AttackCmd(int indexSlot)
    {
        if(currentEquipCard[indexSlot]!= null && indexSlot <= 4)
        {
            currentEquipCard[indexSlot].Attack();
            return indexSlot;
        }
        else
        {
            return 5;
        }
    }
}
