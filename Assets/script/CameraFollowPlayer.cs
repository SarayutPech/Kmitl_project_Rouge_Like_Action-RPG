using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform followTransform;
    public bool foundPlayer = false;

    // Update is called once per frame
    void Update()
    {
        if(foundPlayer == false)
        {
            followTransform = GameObject.FindGameObjectWithTag("Player").transform;
            foundPlayer = true;
        }

        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
    }
}
