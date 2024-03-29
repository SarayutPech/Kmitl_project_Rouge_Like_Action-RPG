using UnityEngine;
using UnityEngine.UI;

public class EquipmentCardSlot : MonoBehaviour
{
    public Image icon;
    public Image uiIcon;
    Item item;
    EquipmentManager equipmentManager;
    UISlotScript uISlotScript;
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
        uiIcon.sprite = item.icon;
        icon.sprite = item.icon;
        //uISlotScript.UIEquipIcon(item.icon);
        icon.enabled = true;

    }

    public void UnEquipItem()
    {
        item = null;
        icon.sprite = null;
        uiIcon.sprite = null;
        //uISlotScript.UIUnEquipIcon();
        icon.enabled = false;
    }

    public void UseItem()
    {
        if (item != null)
        {
            Debug.Log("Unequip " + item.name);
            equipmentManager.Unequip(equipmentManager.currentEquipCard, indexSlotEquipment);
            //equipmentManager.CheckOrderEquipment(equipmentManager.currentEquipCard);
            //equipmentManager.currentEquipCard.
            // int thisIndex = indexSlotEquipment;

        }
    }
}
