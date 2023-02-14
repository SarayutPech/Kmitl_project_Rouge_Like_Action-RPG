using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : Interactable
{
    public Item items;
    public override void Interact()
    {
        PickupItem();
    }

    void PickupItem()
    {
        Debug.Log("Pickup " + items.name);
        bool wasPickUp = Inventory.instance.AddItem(items);

        if (wasPickUp) // Check item is picked up
        {
            Destroy(gameObject); // destroy item
        }
    }
   
}
