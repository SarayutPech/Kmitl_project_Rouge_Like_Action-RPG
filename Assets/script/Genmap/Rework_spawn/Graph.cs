using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Mathematics;

public class Graph : MonoBehaviour
{
    public float posx, posy;
    public Vector3 portalSize;
    private Vector3 posPortalLeft, posPortalRight;
    private Spawn_room sr;
    public LayerMask player;
    private EnemySpawner es;

    private Player_Status ps;
    public GameObject gate_L;
    public GameObject gate_R;


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
            if (playerOnLeft || playerOnRight)
            {
                move();
            }
        }


    }

    //move agent and spawn enemy.
    private void move()
    {
        GameObject[] block_gate;
        RoomTrasition roomTrasition = GameObject.Find("Main Camera").GetComponent<RoomTrasition>();
        roomTrasition.startTrasition();
                       
        posPortalLeft = transform.position + new Vector3(-posx, posy, 0);
        posPortalRight = transform.position + new Vector3(posx, posy, 0);

        // spawn enemy here
        if (!GameObject.Find(ps.wherePlayeris).GetComponent<RoomStatus>().isclear && !GameObject.Find(ps.wherePlayeris).GetComponent<RoomStatus>().isplayed)
            es.canEnemySpawn();

        // �Դ�Դ��е�����������¹��ҹ�͹���
        block_gate = GameObject.FindGameObjectsWithTag("Block_Gate");
        if (!GameObject.Find(ps.wherePlayeris).GetComponent<RoomStatus>().isclear)
        {
            gate_L.SetActive(true);
            gate_R.SetActive(true);
        }
        else
        {
            gate_L.SetActive(false);
            gate_R.SetActive(false);
        }

        ps.transform.position = GameObject.Find("Spawn Point").transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(posPortalRight, portalSize);
        Gizmos.DrawWireCube(posPortalLeft, portalSize);
    }

}

