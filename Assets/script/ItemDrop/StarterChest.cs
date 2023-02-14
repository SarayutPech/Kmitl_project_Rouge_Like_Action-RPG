using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterChest : MonoBehaviour
{
    public WeightedRandomList<Equipment> lootTable;
    //public WeightedRandomList<Object> dropTable;

    private bool isLoot;
    public Openable chest;

    //public Transform itemHolder;


    private void Update()
    {
        if (chest.istrigger == true)
        {
            if (!isLoot)
            {
                ChestOpen();
                ChestOpen();
                ChestOpen();
            }
        }
    }

    

    void ChestOpen()
    {
        Equipment item = lootTable.GetRandom();
        Inventory.instance.AddItem(item);
        Debug.Log("Get " + item.name + " From Chest");
        isLoot = !isLoot;
        /*
        Object itemDrop = dropTable.GetRandom();
        Instantiate(itemDrop, transform.position + positionDrop , Quaternion.identity);
        ;*/
        //itemHolder.gameObject.SetActive(true);
    }
}
