using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{

    public WeightedRandomList<Object> dropTable;
    public Vector3 positionDrop = new Vector3 (0f,0.2f,0f);

    public void destroyObject()
    {
        Destroy(transform.parent.gameObject);
        ItemDrop();
    }

    public void ItemDrop()
    {
        Object itemDrop = dropTable.GetRandom();
        Instantiate(itemDrop, transform.position + positionDrop, Quaternion.identity);
        Debug.Log("Drop " + itemDrop.name + " From Enemy");
    }
}
