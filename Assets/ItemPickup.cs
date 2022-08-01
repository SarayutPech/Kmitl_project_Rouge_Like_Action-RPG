using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public WeaponCard item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {


            Debug.Log("Pickup " + item.name);
            Destroy(gameObject);
        }
    }
}
