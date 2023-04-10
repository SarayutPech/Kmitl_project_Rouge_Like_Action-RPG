using UnityEngine;
using UnityEngine.UI;

public class EquipmentAccSlot : MonoBehaviour
{

    public Image icon;
    Item item;
    EquipmentManager equipmentManager;
    [SerializeField]
    int indexSlotEquipment;

    private void Start()
    {
        equipmentManager = GameObject.Find("GameManager").GetComponent<EquipmentManager>();
        equipmentManager = EquipmentManager.instance;
    }
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
            Debug.Log("Unequip " + item.name);
            equipmentManager.Unequip(equipmentManager.currentEquipAccessory, indexSlotEquipment);
           
            
        }
    }
}
