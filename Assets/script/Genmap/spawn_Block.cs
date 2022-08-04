using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_Block : MonoBehaviour
{
    public GameObject block;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(block, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
