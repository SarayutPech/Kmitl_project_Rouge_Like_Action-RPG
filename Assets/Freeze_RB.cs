using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze_RB : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    void Start()
    {
        rb = transform.root.GetComponent<Rigidbody2D>();        
    }

    public void startFreezePosition()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        //Debug.Log("Freeze");
    }

    public void endFreezePosition()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        //Debug.Log("Unfreeze");
    }
}
