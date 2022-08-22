using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentinel_enemy : MonoBehaviour
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
        Debug.Log("Sentinel : " + findplayer.foundplayer);
        lockRotation();
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
