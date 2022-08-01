using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Card", menuName = "Inventory/Weapon Card")]
public class WeaponCard : ScriptableObject
{
    new public string name = "New Weapon Card";
    public Sprite icon = null;
    public bool isDefaultCard = false;
}
