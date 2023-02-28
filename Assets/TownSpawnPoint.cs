using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownSpawnPoint : MonoBehaviour
{

    public GameObject player;
    public GameObject gameSystem;
    // Start is called before the first frame update
    void Start()
    {
        

        Instantiate(gameSystem);

        SaveSystem saveSystem = GameObject.Find("GameManager").GetComponentInParent<SaveSystem>();
        Instantiate(player, transform.position, Quaternion.identity); // Spawn player
        saveSystem.Load();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
