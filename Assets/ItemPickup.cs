using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item items;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           
            Debug.Log("Pickup " + items.name);
            bool wasPickUp = Inventory.instance.AddItem(items);

            if (wasPickUp) // Check item is picked up
            {
                Destroy(gameObject); // destroy item
            }
            
                                       
        }
    }
}
