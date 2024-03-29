using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyEnemy : MonoBehaviour
{

    public WeightedRandomList<Object> dropTable;
    public Vector3 positionDrop = new Vector3 (0f,0.2f,0f);
    public GameObject warpDoor;

    public void destroyObject()
    {
        Destroy(transform.parent.gameObject);
        try
        {
            ItemDrop();
        }
        catch
        {

        }

        if (SceneManager.GetActiveScene().name == "rework_genmap")
            AddEnemyDefeated();
        else
            AddBossDefeated();
    }

    public void ItemDrop()
    {
        Object itemDrop = dropTable.GetRandom();
        Instantiate(itemDrop, transform.position + positionDrop, Quaternion.identity);
        Debug.Log("Drop " + itemDrop.name + " From Enemy");
    }

    private void AddEnemyDefeated()
    {
        ResultScreen result = GameObject.Find("GameManager").GetComponent<ResultScreen>();
        result.Increase_Enemy_Defeated();
    }

    private void AddBossDefeated()
    {
        ResultScreen result = GameObject.Find("GameManager").GetComponent<ResultScreen>();
        result.Increase_Boss_Defeated();
    }

    public void SpawnWarpDoorToStage()
    {
        GameObject warp = (GameObject)Instantiate(warpDoor, new Vector3(0, -3.6f, -4f), transform.rotation * Quaternion.Euler(0, 0, 0));
    }
}
