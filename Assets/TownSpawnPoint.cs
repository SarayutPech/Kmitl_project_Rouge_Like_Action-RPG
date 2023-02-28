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
        Instantiate(player, transform.position, Quaternion.identity); // Spawn player

        SaveSystem saveSystem = GameObject.Find("GameManager").GetComponentInParent<SaveSystem>();
        saveSystem.Load();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
