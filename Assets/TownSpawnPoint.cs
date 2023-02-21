using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownSpawnPoint : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity); // Spawn player
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
