using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : Interactable
{
    public Sprite open;
    public Sprite close;

    private SpriteRenderer sr;
    private bool isOpen = false;

    public override void Interact()
    {
        if (isOpen)
        {
            sr.sprite = close;
        }
        else
        {
            sr.sprite = open;
            //Chest Open
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = close;
    }

}
