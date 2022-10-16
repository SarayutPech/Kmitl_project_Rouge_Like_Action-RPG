using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fill_empty_room : MonoBehaviour
{
    public LayerMask Room;
    public float sizex, sizey;
    public Vector3 checkRoomPos;
    private Spawn_room sp;

    public GameObject room;

    private void Start()
    {
        sp = GameObject.Find("level manager").GetComponent<Spawn_room>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!SideIsNotNull() && sp.stop_Gen )
        {
            //Debug.Log("Null");
            // Crate Room Here.
            GameObject roomName = (GameObject)Instantiate(room, transform.position + checkRoomPos, Quaternion.identity);
            roomName.name = "Room_R_Filled";
        }
        else if(SideIsNotNull() && sp.stop_Gen)
        {
            Destroy(gameObject);
        }
            
    }

    public bool SideIsNotNull()
    {
        return Physics2D.OverlapBox(transform.position + checkRoomPos, new Vector2(sizex, sizey), 0f, Room);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + checkRoomPos, new Vector2(sizex, sizey));
    }
}
