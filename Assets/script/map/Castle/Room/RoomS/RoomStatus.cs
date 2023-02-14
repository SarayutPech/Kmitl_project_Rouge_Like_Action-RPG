using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStatus : MonoBehaviour
{
    public bool isclear = false;
    public bool isplayed = false;
    public BoxCollider2D col;
    public LayerMask enemy;
    public LayerMask player;
    public float delayForEnemySpawn = 3f;
    private Vector3 roomPosition;
    public Collider2D hitplayer;
    public string biome;

    private void Awake()
    {
        roomPosition = transform.position;
        col = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if (EnemyInRoom() < 1 && isplayed)
        {
            isclear = true;
        }
        isRoomPlayed();

        //Debug.Log(EnemyInRoom());
    }

    public int EnemyInRoom()
    {
        int counting = 0;
        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, col.size, 0, enemy);
        foreach(var i in hit) {
            counting++;
        }

        return counting;
    }

    public void isRoomPlayed()
    {
        hitplayer = Physics2D.OverlapBox(transform.position, col.size, 0, player);

        if (delayForEnemySpawn > 0 && hitplayer)
            delayForEnemySpawn -= Time.deltaTime;
        else if(delayForEnemySpawn < 0 && hitplayer)
            isplayed = true;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, collider.size);
    }*/
}
