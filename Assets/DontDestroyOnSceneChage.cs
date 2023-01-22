using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnSceneChage : MonoBehaviour
{
    public static GameObject instance;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        GameObject.DontDestroyOnLoad(this.gameObject);
    }

}
