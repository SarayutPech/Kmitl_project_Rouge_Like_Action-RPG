using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_room : MonoBehaviour
{
    [Header("GameObject")]
    public GameObject[] room;
    public GameObject warpDoor;
    public GameObject player;
    public GameObject chest;
    public Transform spawnPoint;

    [Header("Agent")]
    public int agentMove_StepLeft;
    private int direction;
    public float moveX,moveY;

    [Header("Status")]
    public bool stop_Gen = false;
    
    [Header("TimeConfig")]
    public float startTimeBtwRoom = 1f;
    private float timeBtwRoom;

    private int SpawnRound = 1;
    private int warpDorCount = 0;

    [Header("RoomPath")]
    public float maxX = 0;
    public float minX = 0;
    public float maxY = 0;


    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(room[1], transform.position, Quaternion.identity); // room R
        GameObject roomName = (GameObject)Instantiate(room[1], transform.position, Quaternion.identity);
        roomName.name = "Started_Room";
        Instantiate(player, spawnPoint.position, Quaternion.identity); // Spawn player

        GameObject DoorBot = (GameObject)Instantiate(warpDoor, transform.position + warpDoor.transform.position, Quaternion.identity);
        DoorBot.name = "Warp_Door_" + warpDorCount;

        direction = 2;
    }

    private void Update()
    {
        if (timeBtwRoom <= 0 && stop_Gen == false)
        {
            Move();
            timeBtwRoom = startTimeBtwRoom;
        }
        else
        {
            timeBtwRoom -= Time.deltaTime;
        }

        /*if(graph_Gen == false && stop_Gen == true)
        {
            generateGraphAstar();
        }*/
    }

    

    private void Move()
    {
        if (direction == 1 || direction == 2) // move Right
        {
            Vector2 newPos = new Vector2(transform.position.x + moveX, transform.position.y); 
            transform.position = newPos; // Move Agent to next position
            maxX += moveX;
            check_Edge();

            direction = Random.Range(1, 6);
            if (direction == 3)
            {
                direction = 2;
            }else if (direction == 4)
            {
                direction = 5;
            }

        }else if (direction == 3 || direction == 4) // move Left
        {
            Vector2 newPos = new Vector2(transform.position.x - moveX, transform.position.y);
            transform.position = newPos;
            if(gameObject.transform.position.x < 0)
                minX -= moveX;
            check_Edge();
            direction = Random.Range(3, 6);
        }
        else if (direction == 5) // move Up
        {
            GameObject chestOb = (GameObject)Instantiate(chest, transform.position + chest.transform.position, Quaternion.identity);
            chestOb.name = "Chest_" + warpDorCount;

            Vector2 newPos = new Vector2(transform.position.x, transform.position.y + moveY);
            transform.position = newPos; // Move Agent to next position
            maxY += moveY;
            check_Edge();

            warpDorCount++;
            GameObject DoorBot = (GameObject)Instantiate(warpDoor, transform.position + warpDoor.transform.position, Quaternion.identity);
            DoorBot.name = "Warp_Door_" + warpDorCount;
            
            direction = Random.Range(1, 6);
        }
        agentMove_StepLeft--;

        if (agentMove_StepLeft == 0)
        {
            stop_Gen = true;
            GameObject chestOb = (GameObject)Instantiate(chest, transform.position + chest.transform.position, Quaternion.identity);
            chestOb.name = "Chest_" + warpDorCount;
            Debug.Log("Last room spawn.");
            maxX += moveX;
            minX -= moveX;
        }
    }
   
    public void check_Edge()
    {
        //LR
        GameObject roomName = (GameObject)Instantiate(room[2], transform.position, Quaternion.identity);
        roomName.name = "Room_" + SpawnRound;
        SpawnRound++;
    }
}
