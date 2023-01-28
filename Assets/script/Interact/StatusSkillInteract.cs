using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusSkillInteract : Interactable
{
    public GameObject statSkillWindows;
    private bool isActive;
    public override void Interact()
    {
        if(isActive == false)
        {
            statSkillWindows.SetActive(true);
        }
        else 
        {
            statSkillWindows.SetActive(false);
        }

        isActive = !isActive;
    }

    // Start is called before the first frame update
    void Start()
    {
        statSkillWindows = GameObject.Find("StatusUI");
        statSkillWindows.SetActive(false);
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
