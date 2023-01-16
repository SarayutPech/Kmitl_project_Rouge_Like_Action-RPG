using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : MonoBehaviour
{
    [Header("Refer all of player status here.")]
    public string wherePlayeris;
    public float floorLevel;

    private Transform levelManager;

    private void Awake()
    {    
        levelManager = GameObject.Find("level manager").transform;
    }

    // Move Level manager agent
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Room"))
        {
            // move level manager agent
            wherePlayeris = collision.name;
            levelManager.transform.position = collision.transform.position;
            //Debug.Log(collision.transform.position);
            AstarPath.active.data.gridGraph.center = collision.transform.position;
                        
        }
               
    }
}
