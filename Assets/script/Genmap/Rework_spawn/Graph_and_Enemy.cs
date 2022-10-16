using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph_and_Enemy : MonoBehaviour
{
    public float posx, posy;
    public Vector3 portalSize;
    private Vector3 posPortalLeft, posPortalRight;
    private Spawn_room sp;
    public LayerMask player;

    private void Start()
    {
        sp = GameObject.Find("level manager").GetComponent<Spawn_room>();

        posPortalLeft = transform.position + new Vector3(-posx, posy, 0);
        posPortalRight = transform.position + new Vector3(posx, posy, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.stop_Gen)
        {
            Collider2D playerOnLeft = Physics2D.OverlapBox(posPortalLeft, portalSize, 0,player);
            if (playerOnLeft)
            {
                move("left");
            }

            Collider2D playerOnRight = Physics2D.OverlapBox(posPortalRight, portalSize, 0,player);
            if (playerOnRight)
            {
                move("right");
            }
        }

    }

    private void move(string dir)
    {
        if( dir == "left")
        {
            AstarPath.active.data.gridGraph.center += new Vector3(-sp.moveX, 0, 0);
            transform.position += new Vector3(-sp.moveX, 0, 0);
        }
            
        else if( dir == "right")
        {
            AstarPath.active.data.gridGraph.center += new Vector3(sp.moveX, 0, 0);
            transform.position += new Vector3(sp.moveX, 0, 0);
        }
        posPortalLeft = transform.position + new Vector3(-posx, posy, 0);
        posPortalRight = transform.position + new Vector3(posx, posy, 0);

        generateGraphAstar();

    }

    private void generateGraphAstar()
    {
        AstarPath.active.Scan(); 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(posPortalRight, portalSize);
        Gizmos.DrawWireCube(posPortalLeft, portalSize);
    }
}
