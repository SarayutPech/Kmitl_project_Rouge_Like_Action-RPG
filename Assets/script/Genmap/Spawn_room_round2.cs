using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_room_round2 : MonoBehaviour
{
    public LayerMask whatIsRoom;
    public Spawn_room spawn_room;
    // Update is called once per frame
    void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
        if (roomDetection == null && spawn_room.stop_Gen == true)
        {
            int rand = Random.Range(0, spawn_room.room.Length);
            Instantiate(spawn_room.room[rand], transform.position, Quaternion.identity);
        }
    }
}
