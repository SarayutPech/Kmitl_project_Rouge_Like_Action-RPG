using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Mathematics;

public class GameState : MonoBehaviour
{
    [Header("Note : This script is always running in game. use for set up game state.")]

    [Header("Agent movestep.")]
    public float posx;
    public float posy;
    [Header("Portal Size and Position.")]
    public Vector3 portalSize;
    private Vector3 posPortalLeft, posPortalRight;
    private Spawn_room sr;
    public LayerMask player;
    private EnemySpawner es;

    [Header("Gate blocker.")]
    private Player_Status ps;
    public GameObject gate_L;
    public GameObject gate_R;

    [Header("Spawn point.")]
    public Transform Spawn_Point_R;
    public Transform Spawn_Point_L;
    public Transform Spawn_Point_C;

    [Header("Player.")]
    public Vector3 WherePlayerAre;

    private void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Status>();
        es = GetComponent<EnemySpawner>();
        sr = GameObject.Find("level manager").GetComponent<Spawn_room>();
        posPortalLeft = transform.position + new Vector3(-posx, posy, 0);
        posPortalRight = transform.position + new Vector3(posx, posy, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (sr.stop_Gen)
        {
            Collider2D playerOnLeft = Physics2D.OverlapBox(posPortalLeft, portalSize, 0,player);
            Collider2D playerOnRight = Physics2D.OverlapBox(posPortalRight, portalSize, 0, player);
            
            if (playerOnLeft)
            {
                move(Spawn_Point_L.position);
               // Debug.Log(Spawn_Point_R.gameObject.name);
            }
            else if (playerOnRight)
            {
                move(Spawn_Point_R.position);
               // Debug.Log(Spawn_Point_L.gameObject.name);
            }

            // เปิดปิดประตูไม่ให้เปลี่ยนด่านตอนเล่น
            if (GameObject.Find(ps.wherePlayeris).GetComponent<RoomStatus>().isclear)
            {
                setGate(false);
            }
            else
            {
                setGate(true);
            }

            posPortalLeft = transform.position + new Vector3(-posx, posy, 0);
            posPortalRight = transform.position + new Vector3(posx, posy, 0);
        }




    }

    private void setGate(bool open)
    {
        gate_L.SetActive(open);
        gate_R.SetActive(open);
    }

    //move agent and spawn enemy.
    public void move(Vector3 pos)
    {
        //ps.transform.position = GameObject.Find("Spawn Point " + dir).transform.position;
        ps.transform.position = pos;

        

        // spawn enemy here
        if (!GameObject.Find(ps.wherePlayeris).GetComponent<RoomStatus>().isclear) //  && !GameObject.Find(ps.wherePlayeris).GetComponent<RoomStatus>().isplayed
            es.canEnemySpawn();
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(posPortalRight, portalSize);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(posPortalLeft, portalSize);
    }*/

}

