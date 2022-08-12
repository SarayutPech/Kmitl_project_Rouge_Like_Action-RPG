using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_tiles_to_BossRoom : MonoBehaviour
{

    private void Start()
    {
        Debug.Log(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tile_remove_able")
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        Debug.Log("Block destroy.");   
    }
}
