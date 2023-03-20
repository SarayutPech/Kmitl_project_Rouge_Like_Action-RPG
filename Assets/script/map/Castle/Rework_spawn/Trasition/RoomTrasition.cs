using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrasition : MonoBehaviour
{
    public GameObject trasition_left;
    public GameObject trasition_right;
    private player_movement player_movement;
    public Animator anim;
    public CameraFollowPlayer cameraFollowPlayer;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        cameraFollowPlayer = GetComponent<CameraFollowPlayer>();
    }


    public void setActiveFalse()
    {
        // «Õ¹à»Ô´
        player_movement = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();
        trasition_left.SetActive(false);
        trasition_right.SetActive(false);
        player_movement.enabled = true;

    }
    public void setActiveTrue()
    {
        // «Õ¹»Ô´
        player_movement = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();
        trasition_left.SetActive(true);
        trasition_right.SetActive(true);
        player_movement.enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        anim.SetTrigger("open");
    }
    public void startTrasition()
    {
        anim.SetTrigger("close");
    }

    private void generateGraphAstar()
    {
        AstarPath.active.Scan();
    }

    private void newCamBorder()
    {
        //find position of level gen
        Transform level_manager = GameObject.Find("level manager").transform;

        cameraFollowPlayer.maxX = level_manager.position.x + 3.5f;
        cameraFollowPlayer.minX = level_manager.position.x - 3.5f;
        cameraFollowPlayer.maxY = level_manager.position.y + 2f;
        cameraFollowPlayer.minY = level_manager.position.y - 2f;
    }
}
