using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public enum ItemType { WeaponCard, Accessory }
    public ItemType itemType;
    public int attack = 0;
    public int Health = 0;
    public Animation animationWeapon;


    public virtual void Use()
    {
        // use item


        Debug.Log("Using " + name);
    }

    public virtual void Attack()
    {
        Debug.Log("Attack With " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.RemoveItem(this);
    }
}


