using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform inventoryCard;
    public Transform inventoryAccessory;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slotsCard;
    InventorySlot[] slotsAccessory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangeCallback += UpdateUI;

        slotsCard = inventoryCard.GetComponentsInChildren<InventorySlot>();
        slotsAccessory = inventoryAccessory.GetComponentsInChildren<InventorySlot>();
        inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory")){
            Debug.Log("Inventory Active");
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {

        for(int i = 0; i < slotsCard.Length; i++)
        {
            if(i < inventory.inventoryCard.Count)
            {
                slotsCard[i].AddItem(inventory.inventoryCard[i]);
            }
            else
            {
                slotsCard[i].ClearSlot();
            }
        }

        for (int i = 0; i < slotsAccessory.Length; i++)
        {
            if (i < inventory.inventoryAccessory.Count)
            {
                slotsAccessory[i].AddItem(inventory.inventoryAccessory[i]);
            }
            else
            {
                slotsAccessory[i].ClearSlot();
            }
        }

        Debug.Log("Update UI");
    }
}
