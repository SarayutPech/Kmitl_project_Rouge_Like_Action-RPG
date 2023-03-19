using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardChest : Interactable
{
    public Animator anim;
    public bool notOpen = true;
    public GameObject key_rawImg;

    private LevelManagerParameter levelManagerParameter;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        levelManagerParameter = GameObject.Find("level manager").GetComponent<LevelManagerParameter>();
    }

    private void giveReward()
    {
        // give key
        anim.SetTrigger("Open");
        levelManagerParameter.givekeys();
        // give Item
    }

    
    public override void Interact()
    {
        notOpen = false;
        // Do something
        giveReward();
        
    }
}
