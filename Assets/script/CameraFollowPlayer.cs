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
        try
        {
            if (GameObject.Find("level manager").transform != null)
                Stage_border = GameObject.Find("level manager").transform;
        }
        catch
        {
            Debug.Log("can't find level manager");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(foundPlayer == false)
        {
            try
            {
                followTransform = GameObject.FindGameObjectWithTag("Player").transform;
                foundPlayer = true;
            }
            catch
            {
                Debug.Log("No player in Scene.");
            }

        }

        camMove();
    }

    private void camMove()
    {
        
        if(Stage_border != null)
            transform.position = new Vector3(Mathf.Clamp(followTransform.position.x, minX, maxX), Mathf.Clamp(followTransform.position.y, minY, maxY), transform.position.z);
        else
            this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
    }

    
}
