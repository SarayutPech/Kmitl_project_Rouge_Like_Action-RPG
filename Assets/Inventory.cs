using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Inventory more than one instance !");
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangeCallback;

    public List<Item> inventoryCard = new List<Item>();
    public List<Item> inventoryAccessory = new List<Item>();

    public int InventoryCardSlot = 20;
    public int InventoryAccessorySlot = 20;

    public bool AddItem (Item item)
    {
        // Add Weapon Card
        if (!item.isDefaultItem && item.itemType == Item.ItemType.WeaponCard)
        {
            if(inventoryCard.Count >= InventoryCardSlot)
            {
                Debug.Log("Not Enough Space");
                return false;
            }

            inventoryCard.Add(item);

            if (onItemChangeCallback != null)
            {
                onItemChangeCallback.Invoke();
            }
            // Add Accessory
        }
        else if (!item.isDefaultItem && item.itemType == Item.ItemType.Accessory)
        {
            if (inventoryAccessory.Count >= InventoryAccessorySlot)
            {
                Debug.Log("Not Enough Space");
                return false;
            }
            
            inventoryAccessory.Add(item);

            if (onItemChangeCallback != null)
            {
                onItemChangeCallback.Invoke();
            }
        }
        return true;
    }

    public void RemoveItem (Item item)
    {
        if (item.itemType == Item.ItemType.WeaponCard)
        {
            inventoryCard.Remove(item);
        }
        else if (item.itemType == Item.ItemType.Accessory)
        {
            inventoryAccessory.Remove(item);
        }

        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }
    }


}
