using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_room : MonoBehaviour
{

    public Transform[] startingPos;
    public GameObject[] room;

    private int direction;
    public float moveX,moveY,minX,maxX,maxY;
    private bool stop_Gen = false;


    private float timeBtwRoom;
    public float startTimeBtwRoom = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(room[4], transform.position, Quaternion.identity); // room R
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
    }

    private void Move()
    {
        if(direction == 1 || direction == 2) // move Right
        {
            if (transform.position.x < maxX)
            {
                Vector2 newPos = new Vector2(transform.position.x + moveX, transform.position.y);
                transform.position = newPos;

                check_Edge();

                direction = Random.Range(1, 6);
                if (direction == 3)
                {
                    direction = 2;
                }else if (direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }
            
        }else if (direction == 3 || direction == 4) // move Left
        {
            if (transform.position.x > minX)
            {
                Vector2 newPos = new Vector2(transform.position.x - moveX, transform.position.y);
                transform.position = newPos;

                check_Edge();

                direction = Random.Range(3, 6);
            }
            else
            {
                direction = 5;
            }

        }
        else if (direction == 5) // move Up
        {
            if(transform.position.y < maxY){
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y + moveY);
                transform.position = newPos;

                check_Edge();

                direction = Random.Range(1, 6);
            }
            else
            {
                stop_Gen = true;
            }
            
        }

        //Instantiate(room[0], transform.position, Quaternion.identity);
        
    }

    void check_Edge()
    {
        if (transform.position.x == maxX && transform.position.y < maxY && transform.position.y > 0)
        {
            Instantiate(room[2], transform.position, Quaternion.identity); // Room LBT
        }
        else if (transform.position.x == maxX && transform.position.y == 0)
        {
            Instantiate(room[3], transform.position, Quaternion.identity); // Room LT
        }
        else if (transform.position.x == maxX && transform.position.y == maxY)
        {
            Instantiate(room[1], transform.position, Quaternion.identity); // Room LB
        }

        else if (transform.position.x == minX && transform.position.y < maxY && transform.position.y > 0)
        {
            Instantiate(room[7], transform.position, Quaternion.identity); // Room RBT
        }
        else if (transform.position.x == minX && transform.position.y == 0)
        {
            Instantiate(room[6], transform.position, Quaternion.identity); // Room RT
        }
        else if (transform.position.x == minX && transform.position.y == maxY)
        {
            Instantiate(room[5], transform.position, Quaternion.identity); // Room RB
        }

        else if (transform.position.y == 0)
        {
            Debug.Log(1);
            Instantiate(room[10], transform.position, Quaternion.identity); // Room LTR ( No B )
        }
        else if (transform.position.y == maxY)
        {
            Debug.Log(2);
            GameObject[] randRoom = new GameObject[2];
            randRoom[0] = room[11];
            randRoom[1] = room[8];

            int rand = Random.Range(0, randRoom.Length);
            Instantiate(randRoom[rand], transform.position, Quaternion.identity); //Room LBR ( No T )
        }
        else
        {
            Instantiate(room[9], transform.position, Quaternion.identity);
        }
    }
}
