using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform followTransform;
    public bool foundPlayer = false;

    public Transform Stage_border;

    public float smooth = 3;

    public float maxX;
    public float maxY;
    public float minX;
    public float minY;

    private void Start()
    {
        Stage_border = GameObject.Find("level manager").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(foundPlayer == false)
        {
            followTransform = GameObject.FindGameObjectWithTag("Player").transform;
            foundPlayer = true;
        }

        camMove();
    }

    private void camMove()
    {
        //this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(followTransform.position.x, minX, maxX), Mathf.Clamp(followTransform.position.y, minY, maxY), transform.position.z);
    }

    
}
