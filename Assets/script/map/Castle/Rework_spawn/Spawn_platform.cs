using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_platform : MonoBehaviour
{
    // Hide component
    private Spawn_room sp;
    [SerializeField]private bool start_Gen = false;
    [SerializeField]private bool stop_Gen = false;

    [Header("Decor \n---------------------------------------------------------------------------------------------------------------------")]
    public GameObject[] decorCastle;
    public GameObject[] decorNeon;
    public GameObject[] decorPirate;

    [Header("")]
    [Header("BlockToSpawn \n---------------------------------------------------------------------------------------------------------------------")]
    public GameObject blockLeft;
    public GameObject blockRight;
    public GameObject[] blockTop;
    public GameObject[] blockTopLeft;
    public GameObject[] blockTopRight;
    public GameObject blockBot;
    public GameObject blockBotLeft;
    public GameObject blockBotRight;
    public GameObject blockCenter;
    public GameObject oneWayPlatform;
    public GameObject noBlock;

    [Header("")]
    [Header("RoomOverView \n---------------------------------------------------------------------------------------------------------------------")]
    public int roomSizeX = 16;
    public int roomSizeY = 7;
    
    public float decorGenLevel = 0.2f;

    [Header("")]
    [Header("platform algorithm : Horizontal \n---------------------------------------------------------------------------------------------------------------------")]
    public float horPlatformGenLevel = 0.6f;
    public float horStartX;
    public float horScale = 0.1f;
    public float horBlockScale = 1f;
    public int horStepY = 3;
    public float horStartY = 3.25f;
    public int[] horRandomYRange;


    [Header("")]
    [Header("platform algorithm : Vertical \n---------------------------------------------------------------------------------------------------------------------")]
    public float verPlatformGenLevel = 0.6f;
    public float verStartY = 3.25f;
    public float verScale = 0.1f;
    public float verBlockScale = 1f;
    public int verStepX = 3;
    public int verStopSpawnX = 9;
    public int verStartSpawnX = 20;
    public int[] verYSpace;
    public int[] verRandomYRange;

    [Header("Biome List : 0 castle , 1 neon \n---------------------------------------------------------------------------------------------------------------------")]
    public int biome;

    [Header("")]
    [Header("Layer")]
    public LayerMask safeRoomObject;
    public LayerMask room;
    
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<Spawn_room>();
    }

    private void Update()
    {
        if (sp.stop_Gen && !start_Gen) {
            resetTransform();
            transform.position = new Vector2(sp.moveX, 0);
        }

        if(!stop_Gen)
        {
            if (start_Gen && onRoom())
            {
                getBiome();
                if (!isSafeRoom()) {
                    RandomPlacePlatform();
                }
                move();
            }
            else if (start_Gen && !onRoom())
            {
                move();
            }
        }
        
    }
    private void resetTransform(float y = 0)
    {
        transform.position = new Vector2(sp.minX ,transform.position.y + y);
        start_Gen = true;
    }
    
    private void RandomPlacePlatform()
    {
        int rand = Random.Range(1, 3);
        switch (rand)
        {
            case 1:
                placeHorizontalPlatform();
                break;
            case 2:
                placeVerticalPlatform();
                break;
        }
    }

    private float[,] noiseMaping(int roomSizeForMapingX, int roomSizeForMapingY)
    {
        float[,] noiseMap = new float[roomSizeForMapingX, roomSizeForMapingY];
        float seedX = Random.Range(-1000f, 1000f);
        float seedY = Random.Range(-1000f, 1000f);

        // Map noise เข้า Array
        for (int y = 0; y < roomSizeForMapingY; y++)
        {
            for (int x = 0; x < roomSizeForMapingX; x++)
            {
                float noiseValue = Mathf.PerlinNoise(x * horScale + seedX, y * horScale + seedY);
                if (x == 0 || y == 0 || x == roomSizeX - 1 || y == roomSizeY - 1)
                    noiseMap[x, y] = 1;
                else
                    noiseMap[x, y] = noiseValue;
            }
        }

        return noiseMap;
    }

    private void placeHorizontalPlatform()
    {
        float[,] noiseMap = new float[roomSizeX, roomSizeY];
        noiseMap = noiseMaping(roomSizeX, roomSizeY);
        horStepY = Random.Range( horRandomYRange[0], horRandomYRange[1] );

        // เอา noise ที่ Map ไว้มา spawn platform
        for(int y = 1; y < roomSizeY-1; y += horStepY)
        {
            for (int x = 1; x < roomSizeX-1; x ++)
            {
                float noiseValue = noiseMap[x, y];

                Vector3 pos = new Vector2(x * horBlockScale + horStartX, y * horBlockScale - horStartY);
                if (noiseValue < horPlatformGenLevel)
                {
                    GameObject placed_block = (GameObject)Instantiate(blockToPlace(
                        noiseMap[x-1, y] < horPlatformGenLevel,
                        noiseMap[x+1, y] < horPlatformGenLevel,
                        biome
                        ),transform.position + pos, Quaternion.identity);
                    placed_block.name = "block " + pos;
                    placed_block.transform.parent = GameObject.Find("platforms").transform;

                    
                }
                // วาง Decor
                if (noiseValue < horPlatformGenLevel - decorGenLevel)
                {
                        Vector3 decorPos = new Vector2(x * horBlockScale + horStartX, y * horBlockScale - horStartY + 0.25f);
                        GameObject placed_Decor = (GameObject)Instantiate(DecorToPlace(biome), transform.position + decorPos, Quaternion.identity);
                        placed_Decor.transform.parent = GameObject.Find("Decors").transform;
                
                }
            }
        }
    }

    private void placeVerticalPlatform()
    {
        float[,] noiseMap = new float[roomSizeX, roomSizeY+8];
        noiseMap = noiseMaping(roomSizeX, roomSizeY+8);

        float seedX = Random.Range(-1000f, 1000f);
        float seedY = Random.Range(-1000f, 1000f);

        verStepX = Random.Range(verRandomYRange[0], verRandomYRange[1]);

        // เอา noise ที่ Map ไว้มา spawn platform
        for (int y = 1; y < roomSizeY + 7; y++)
        {
            for (int x = 1; x < roomSizeX - 1; x+=verStepX)
            {
                float noiseValue = noiseMap[x, y];

                Vector3 pos = new Vector2(x * horBlockScale + horStartX, y * horBlockScale + verStartY);
                if (noiseValue < verPlatformGenLevel && ( x < verStopSpawnX || x > verStartSpawnX ) && ( y < verYSpace[0] + RanInt(10) || y > verYSpace[1] + RanInt(10)))  
                {
                    GameObject placed_block = (GameObject)Instantiate(blockToPlace(
                        noiseMap[x - 1, y] < verPlatformGenLevel,
                        noiseMap[x + 1, y] < verPlatformGenLevel,
                        biome
                        ), transform.position + pos, Quaternion.identity);
                    placed_block.name = "block " + pos;
                    placed_block.transform.parent = GameObject.Find("platforms").transform;

                }
            }
        }
    }


    GameObject blockToPlace(bool left, bool right, int biome)
    {
        if(!left && !right)
            return noBlock;
        else if (left && right)
            return blockTop[biome];
        else if (!left && right)
            return blockTopLeft[biome];
        else if (left && !right)
            return blockTopRight[biome];


        return noBlock;
    }

    GameObject DecorToPlace(int biome)
    {
        GameObject[] DecorBiome = decorPirate;
        switch (biome)
        {
            case 0:
                DecorBiome = decorCastle;
                break;
            case 1:
                DecorBiome = decorNeon;
                break;
            case 2:
                DecorBiome = decorPirate;
                break;
        }
        return DecorBiome[RanInt(DecorBiome.Length)];
    }

    private void move()
    {
        if (transform.position.x < sp.maxX)
            transform.position += new Vector3(sp.moveX, 0, 0);
        else if (transform.position.x >= sp.maxX && transform.position.y < sp.maxY)
            resetTransform(sp.moveY);
        else
        {
            stop_Gen = true;
            transform.position = new Vector2(0, 0);
        }
        
    }

    private void getBiome()
    {
        Collider2D BiomeCheck = Physics2D.OverlapBox(gameObject.transform.position, new Vector2(5, 5), 0f, room);
        if (BiomeCheck)
        {
            switch (BiomeCheck.GetComponent<RoomStatus>().biome)
            {
                case "Castle":
                    biome = 0;
                    break;
                case "Neon":
                    biome = 1;
                    break;
                case "Pirate":
                    biome = 2;
                    break;
            }
        }
    }

    private bool onRoom()
    {
        //Debug.Log( Physics2D.OverlapBox(transform.position, new Vector2(5, 5), 0f, room) );
        return Physics2D.OverlapBox(transform.position, new Vector2(5, 5), 0f, room);
    }

    private bool isSafeRoom()
    {
        //Debug.Log( Physics2D.OverlapBox(transform.position, new Vector2(5, 5), 0f, room) );
        return Physics2D.OverlapBox(transform.position, new Vector2(16, 9), 0f, safeRoomObject);
    }

    public int RanInt(int Range = 0)
    {
        return Random.Range(0, Range);
    }
}
