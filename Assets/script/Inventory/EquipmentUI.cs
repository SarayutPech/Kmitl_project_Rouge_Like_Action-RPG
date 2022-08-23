using UnityEngine;

public class EquipmentUI : MonoBehaviour
{

    public Transform equipmentCard;
    public Transform equipmentAccessory;
    public GameObject equipmentUI;

    EquipmentCardSlot[] equipCardSlot;
    EquipmentAccSlot[] equipAccSlot;

    EquipmentManager equipmentManager;
    // Start is called before the first frame update
    void Start()
    {
        equipmentManager = EquipmentManager.instance;
        equipmentManager.onEquipCallback += UpdateEquipmentUI;

        equipCardSlot = equipmentCard.GetComponentsInChildren<EquipmentCardSlot>();
        equipAccSlot = equipmentAccessory.GetComponentsInChildren<EquipmentAccSlot>();

    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            Debug.Log("Inventory Active");
            equipmentUI.SetActive(!equipmentUI.activeSelf);
        }
    }

    void UpdateEquipmentUI()
    {
        for (int i = 0; i < equipCardSlot.Length; i++)
        {
            if (equipmentManager.currentEquipCard[i]!= null)
            {
                equipCardSlot[i].EquipItem(equipmentManager.currentEquipCard[i]);
            }
            else
            {
                equipCardSlot[i].UnEquipItem();
            }
        }

        for (int i = 0; i < equipAccSlot.Length; i++)
        {
            if (equipmentManager.currentEquipAccessory[i] != null)
            {
                equipAccSlot[i].EquipItem(equipmentManager.currentEquipAccessory[i]);
            }
            else
            {
                equipAccSlot[i].UnEquipItem();
            }
        }

        Debug.Log("Update UI Equipment");
    } 


    }
