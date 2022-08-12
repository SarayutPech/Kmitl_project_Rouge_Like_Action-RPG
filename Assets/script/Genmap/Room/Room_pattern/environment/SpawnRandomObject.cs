using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomObject : MonoBehaviour
{
    public GameObject[] Ob;
    // Update is called once per frame
    void Start()
    {
        
        int rand = Random.Range(0, Ob.Length);
        GameObject instance = (GameObject)Instantiate(Ob[rand], transform.position, Quaternion.identity);

        instance.transform.parent = transform;
    }
}
