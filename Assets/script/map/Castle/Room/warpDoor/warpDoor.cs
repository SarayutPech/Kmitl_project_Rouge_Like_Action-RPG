using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class warpDoor : Interactable
{
    private GameState gameState;
    private Player_Status ps;
    public Vector3 Player_spawn;

    public float timeForPlayerMoveWhenEnterTheDoorBase;
    private float timeForPlayerMoveWhenEnterTheDoorCounting;

    private LevelManagerParameter levelManagerParameter;
    private void Awake()
    {
        try
        {
            gameState = GameObject.Find("level manager").GetComponent<GameState>();
            ps = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Status>();
            levelManagerParameter = GameObject.Find("level manager").GetComponent<LevelManagerParameter>();
        }
        catch
        {
            Debug.Log("can't find GameState.");
        }
    }

    private void goToBossRoom()
    {
        int rand = Random.Range(0, 2);
        switch (rand)
        {
            case 0:
                SceneManager.LoadScene("Boss_Castle");
                break;
            case 1:
                SceneManager.LoadScene("Boss_Castle_2");
                break;
        }
        //SceneManager.LoadScene("Boss_Castle_ML");

        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-7,0,-5);
        
    }

    public override void Interact()
    {
        if(levelManagerParameter.keys == true)
        {
            ps.floorLevel += 1;
            if (GameObject.Find("Warp_Door_" + ps.floorLevel)) // มีชั้นต่อไป
            {
                gameState.MoveUp = true;
                MovePlayer();
                //Update Game Result
                ResultScreen result = GameObject.Find("GameManager").GetComponent<ResultScreen>();
                result.Increase_Floor_Reach();

            }
            else if(SceneManager.GetActiveScene().name == "rework_genmap") // อยู่บนยอดแล้ว 
            {
                // ส่งไปซีนต่อไป
                goToBossRoom();
            }
            
            levelManagerParameter.usekeys();
        }
        else if(SceneManager.GetActiveScene().name != "rework_genmap")
        {
            SceneManager.LoadScene("rework_genmap");
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-7, -1, -5);
        }
    }

    void MovePlayer()
    {
        gameState.WherePlayerAre = GameObject.Find("Warp_Door_" + ps.floorLevel).transform.position + Player_spawn;
        RoomTrasition roomTrasition = GameObject.Find("Main Camera").GetComponent<RoomTrasition>();
        roomTrasition.startTrasition();
    }

}
