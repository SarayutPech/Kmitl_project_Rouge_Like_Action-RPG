using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enterable : Interactable
{
    public override void Interact()
    {
        goToDungeon();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void goToDungeon()
    {
        SceneManager.LoadScene("rework_genmap");
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-7, -1, -5);
    }
}
