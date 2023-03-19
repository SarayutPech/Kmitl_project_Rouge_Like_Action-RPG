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

    private LevelManagerParameter levelManagerParameter;
    private void Awake()
    {
        gameState = GameObject.Find("level manager").GetComponent<GameState>();
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Status>();
        levelManagerParameter = GameObject.Find("level manager").GetComponent<LevelManagerParameter>();
    }

    private void goToBossRoom()
    {
        SceneManager.LoadScene("Boss_Castle");
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-7,-1,-5);
    }

    public override void Interact()
    {
        if(levelManagerParameter.keys == true)
        {
            ps.floorLevel += 1;
            if (GameObject.Find("Warp_Door_" + ps.floorLevel)) // มีชั้นต่อไป
            {
                gameState.move(GameObject.Find("Warp_Door_" + ps.floorLevel).transform.position + Player_spawn);

                //Update Game Result
                ResultScreen result = GameObject.Find("GameManager").GetComponent<ResultScreen>();
                result.Increase_Floor_Reach();

            }
            else // อยู่บนยอดแล้ว 
            {
                // ส่งไปซีนต่อไป
                goToBossRoom();
            }
            levelManagerParameter.usekeys();
        }
    }
}
