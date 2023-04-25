using UnityEngine;
using UnityEngine.UI;
using System.Text;
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    TooltipTrigger itemDetail;
    Item item;

    public void AddItem (Item newItem)
    {
        item = newItem;
        itemDetail = GetComponent<TooltipTrigger>();

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        itemDetail.header = item.name;
        itemDetail.content = CheckDetail(item);

    }

    private string CheckDetail(Item item)
    {
        StringBuilder detailItem = new StringBuilder("");
        if(item.attack_Modifier > 0)
        {
            detailItem.Append($"ATK +{item.attack_Modifier}\n");
        }
        if (item.critRate_Modifier > 0)
        {
            detailItem.Append($"Cri Rate +{item.critRate_Modifier}\n");
        }
        if (item.critDamage_Modifier > 0)
        {
            detailItem.Append($"Cri Dmg +{item.critDamage_Modifier}\n");
        }
        if (item.moveSpeed_Modifier > 0)
        {
            detailItem.Append($"Speed +{item.attack_Modifier}\n");
        }
        if (item.dropRate_Modifier > 0)
        {
            detailItem.Append($"Drop +{item.dropRate_Modifier}\n");
        }
        if (item.health_Modifier > 0)
        {
            detailItem.Append($"HP +{item.health_Modifier}\n");
        }

        return detailItem.ToString();
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.RemoveItem(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}
