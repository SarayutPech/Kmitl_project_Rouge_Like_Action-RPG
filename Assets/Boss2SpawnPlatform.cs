using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2SpawnPlatform : MonoBehaviour
{
    public GameObject BossPlatform;
    public float[] AreaToSpawnX;
    public float[] AreaToSpawnY;
    public int[] RandRange;
    public int platformToPlace;
    public int platformCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        platformToPlace = Random.Range(RandRange[0], RandRange[1]);
    }

    private void Update()
    {
        if(platformCount < platformToPlace)
        {
            GameObject Platform = (GameObject)Instantiate(BossPlatform, new Vector3(Random.RandomRange(AreaToSpawnX[0], AreaToSpawnX[1]),
                Random.RandomRange(AreaToSpawnY[0], AreaToSpawnY[1]),
                -3), transform.rotation * Quaternion.Euler(0, Random.RandomRange(15, 75), 0));
            Platform.GetComponent<MovePlatform>().dir = Random.RandomRange(0, 4);
            Platform.name = "Platform";
            platformCount++;
        }
    }
}
