using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystemScript : MonoBehaviour
{
    public static GameSystemScript instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
