using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn_room : MonoBehaviour
{
    [Header("Note : This script is run only one time. we only use Stop_Gen when all room created.")]
    private LevelManagerParameter levelManagerParameter;

    [Header("GameObject.")]
    public GameObject[] room;
    public GameObject warpDoor;
    public GameObject player;
    public GameObject chest;
    public Transform spawnPoint;

    [Header("Agent property.")]
    private int direction;
    public float moveX,moveY;

    [Header("Room border. just for veiw don't need to assign")]
    public float maxX = 0;
    public float minX = 0;
    public float maxY = 0;
    
    [Header("TimeConfig.")]
    [Tooltip("Time to create next room. (sec)")]
    public float startTimeBtwRoom = 1f;
    private float timeBtwRoom;

    private int SpawnRound = 1;
    private int warpDorCount = 0;

    [Header("Status.")]
    [Tooltip("True : all room created.")]
    public bool stop_Gen = false;
    public bool fast_Gen = true;

    [Header("Spawn Player.")]
    [SerializeField]
    bool spawnPlayer;

    public Spawn_platform sp;


    // Start is called before the first frame update
    void Start()
    {
        sp.enabled = false;
        //Instantiate(room[1], transform.position, Quaternion.identity); // room R
        //GameObject roomName = (GameObject)Instantiate(room[1], transform.position, Quaternion.identity);
        //roomName.name = "Started_Room";
        levelManagerParameter = GetComponent<LevelManagerParameter>();

        if (spawnPlayer)
        {
           Instantiate(player, spawnPoint.position, Quaternion.identity); // Spawn player
        }


        GameObject DoorBot = (GameObject)Instantiate(warpDoor, transform.position + warpDoor.transform.position, Quaternion.identity);
        DoorBot.name = "Warp_Door_" + warpDorCount;
        DoorBot.transform.parent = GameObject.Find("warp&key").transform;
        direction = 2;
    }

    private void Update()
    {

        CheckErrorMap();

        if (!fast_Gen)
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
        }
        else
        {
            if(stop_Gen == false)
            {
                Move();
                timeBtwRoom = startTimeBtwRoom;
            }
        }

        
    }

    private void CheckErrorMap()
    {
        
        GameObject[] warpDoor = GameObject.FindGameObjectsWithTag("Warp");
        for (int i=0; i < warpDoor.Length - 1; i++)
        {
            Debug.Log("I -> " + i);
            int wDoorPos1 = (int)warpDoor[i].transform.position.y;

            for (int j = i+1; j < warpDoor.Length; j++)
            {
                int wDoorPos2 = (int)warpDoor[j].transform.position.y;
                if (wDoorPos1 == wDoorPos2)
                {

                    SceneManager.LoadScene("rework_genmap");
                    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-7, -1, -5);

                    Debug.Log("Map Error");
                }
            }     
        }

        GameObject[] RewardChests = GameObject.FindGameObjectsWithTag("RewardChest");
        for (int i = 0; i < RewardChests.Length - 1; i++)
        {
            Debug.Log("I -> " + i);
            int RewardChestPos1 = (int)warpDoor[i].transform.position.y;

            for (int j = i + 1; j < RewardChests.Length; j++)
            {
                int RewardChestPos2 = (int)warpDoor[j].transform.position.y;
                if (RewardChestPos1 == RewardChestPos2)
                {

                    SceneManager.LoadScene("rework_genmap");
                    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-7, -1, -5);

                    Debug.Log("Map Error");
                }
            }
        }

    }

    private void Move()
    {
        switch (direction)
        {
            case 1:
            case 2:
                MoveRight();
                break;
            case 3:
            case 4:
                MoveLeft();
                break;
            case 5:
                MoveUp();
                break;
        }
        levelManagerParameter.agentMoveStep--;

        if (levelManagerParameter.agentMoveStep <= 0) // Last Room
        {
            LastRoomObject();
        }
    }
   
    private void MoveRight()
    {
        Vector2 newPos = new Vector2(transform.position.x + moveX, transform.position.y);
        transform.position = newPos; // Move Agent to next position
        maxX += moveX;
        check_Edge();

        direction = Random.Range(1, 6);
        if (direction == 3)
        {
            direction = 2;
        }
        else if (direction == 4)
        {
            direction = 5;
        }
    }

    private void MoveLeft()
    {
        Vector2 newPos = new Vector2(transform.position.x - moveX, transform.position.y);
        transform.position = newPos;
        if (gameObject.transform.position.x < 0)
            minX -= moveX;
        check_Edge();
        direction = Random.Range(3, 6);
    }

    private void MoveUp()
    {
        GameObject chestOb = (GameObject)Instantiate(chest, transform.position + chest.transform.position, Quaternion.identity);
        chestOb.name = "Chest_" + warpDorCount;
        chestOb.transform.parent = GameObject.Find("warp&key").transform;

        Vector2 newPos = new Vector2(transform.position.x, transform.position.y + moveY);
        transform.position = newPos; // Move Agent to next position
        maxY += moveY;
        check_Edge();

        warpDorCount++;
        GameObject DoorBot = (GameObject)Instantiate(warpDoor, transform.position + warpDoor.transform.position, Quaternion.identity);
        DoorBot.name = "Warp_Door_" + warpDorCount;
        DoorBot.transform.parent = GameObject.Find("warp&key").transform;

        direction = Random.Range(1, 6);
    }

    private void LastRoomObject()
    {
        stop_Gen = true;
        GameObject chestOb = (GameObject)Instantiate(chest, transform.position + chest.transform.position, Quaternion.identity);
        chestOb.name = "Chest_" + warpDorCount;
        chestOb.transform.parent = GameObject.Find("warp&key").transform;
        //Debug.Log("Last room spawn.");
        maxX += moveX;
        minX -= moveX;
        sp.enabled = true;


    }

    public void check_Edge()
    {
        //LR
        GameObject roomName = (GameObject)Instantiate(SpawnRoom(), transform.position, Quaternion.identity);
        roomName.name = "Room_" + SpawnRound;
        roomName.transform.parent = GameObject.Find("rooms").transform;
        SpawnRound++;
    }

    private GameObject SpawnRoom()
    {
        int rand = Random.Range(0, room.Length);
        return room[rand];  
    }
}
