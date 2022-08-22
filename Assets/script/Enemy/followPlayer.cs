using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public findPlayer findplayer;
    public float speed;
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        Debug.Log(findplayer.foundplayer);
        lockRotation();
        if (findplayer.foundplayer == true)
        {   
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        if (gameObject.tag == "Enemy_Fly")
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y),
                new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);



    }

    void lockRotation()
    {
        transform.eulerAngles = new Vector3(
        0,
        transform.eulerAngles.y,
        0
        );
    }
}
