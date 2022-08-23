using UnityEngine;
using UnityEngine.UI;

public class EquipmentCardSlot : MonoBehaviour
{
    public Image icon;

    Item item;
    EquipmentManager equipmentManager;
    public void EquipItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void UnEquipItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if (item != null)
        {
            Debug.Log("Unequip "+ item.name);
        }
    }
}
