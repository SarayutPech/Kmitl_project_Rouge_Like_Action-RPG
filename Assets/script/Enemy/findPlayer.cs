using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findPlayer : MonoBehaviour
{
    public bool foundplayer = false;
    
    // looking for player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foundplayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.tag == "Enemy_Sentinel")
        {
            foundplayer = false;
            Debug.Log("Sentinel off!");
        }
    }
}
