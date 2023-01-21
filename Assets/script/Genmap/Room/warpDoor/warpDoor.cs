using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class warpDoor : MonoBehaviour
{
    public float x, y;
    public LayerMask player;
    public GameObject slider;
    private float progressBar = 0;

    private GameState gameState;
    private Player_Status ps;
    public Vector3 Player_spawn;

    public float maxProgressValue;

    private LevelManagerParameter levelManagerParameter;
    private void Awake()
    {
        gameState = GameObject.Find("level manager").GetComponent<GameState>();
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Status>();
        slider.GetComponent<Slider>().maxValue = maxProgressValue;
        levelManagerParameter = GameObject.Find("level manager").GetComponent<LevelManagerParameter>();
    }

    private void Update()
    {
        Collider2D playerCol = Physics2D.OverlapBox(transform.position, new Vector2(x, y), 0f, player);
        if (playerCol)
        {
            slider.SetActive(true);
            if(progressBar < maxProgressValue)
            {
                progressBar += Time.deltaTime;
                slider.GetComponent<Slider>().value = progressBar;
            }else if(progressBar >= maxProgressValue && levelManagerParameter.keys == true)
            {
                ps.floorLevel += 1;
                if (GameObject.Find("Warp_Door_" + ps.floorLevel)) // มีชั้นต่อไป
                {
                    gameState.move(GameObject.Find("Warp_Door_" + ps.floorLevel).transform.position + Player_spawn);
                }else // อยู่บนยอดแล้ว 
                {
                    // ส่งไปซีนต่อไป
                }
                progressBar = 0;
                levelManagerParameter.usekeys();
            }
            else
            {
                slider.SetActive(false);
            }
        }
        else
        {
            slider.SetActive(false);
            progressBar = 0;
        }
    }

    public void interact()
    {
        Debug.Log(gameObject.name);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position,new Vector2(x, y));
    }
}
