using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusSkillInteract : Interactable
{
    public GameObject statSkillWindows;
    public GameObject tooltipUI;
    private bool isActive;
    public override void Interact()
    {
        if(isActive == false)
        {
            statSkillWindows.SetActive(true);
            tooltipUI.SetActive(true);
        }
        else 
        {
            statSkillWindows.SetActive(false);
            tooltipUI.SetActive(false);
        }

        isActive = !isActive;
    }

    // Start is called before the first frame update
    void Start()
    {
        tooltipUI = GameObject.Find("TooltipCanvas");
        statSkillWindows = GameObject.Find("StatusUI");
        statSkillWindows.SetActive(false);
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<InteractScript>().CloseInteractIcon();
            statSkillWindows.SetActive(false);
            tooltipUI.SetActive(false);
            isActive = false;
        }
    }
}
