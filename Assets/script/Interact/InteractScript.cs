using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{

    public GameObject interactIcon;


    private Vector2 boxSize = new Vector2(0.1f, 1f);
    private bool isInteract;
    // Start is called before the first frame update
    void Start()
    {
        interactIcon.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CheckInteract();
            Debug.Log("Press F button");
        }
    }

    public void OpenInteractIcon()
    {
        interactIcon.SetActive(true);
        isInteract = true;
    }

    public void CloseInteractIcon()
    {
        interactIcon.SetActive(false);
        isInteract = false;
    }

    private void CheckInteract()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if(hits.Length > 0 && isInteract)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                }
            }
        }
    }
}
