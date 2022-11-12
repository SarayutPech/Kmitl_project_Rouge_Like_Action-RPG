using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_platform : MonoBehaviour
{
    private Spawn_room sp;
    private EnemySpawner es;
    [SerializeField]private bool start_Gen = false;
    [SerializeField]private bool stop_Gen = false;
    
    [Header("BlockToSpawn")]
    public GameObject blockLeft;
    public GameObject blockRight;
    public GameObject blockTop;
    public GameObject blockTopLeft;
    public GameObject blockTopRight;
    public GameObject blockBot;
    public GameObject blockBotLeft;
    public GameObject blockBotRight;
    public GameObject blockCenter;
    public GameObject oneWayPlatform;
    public GameObject noBlock;

    public int roomSizeX = 16;
    public int roomSizeY = 7;
    public float startX;
    public float scale = 0.1f;
    public float blockScale = 1f;
    public int stepY = 3;
    public int[] randomYRange;

    public float platformGenLevel = 0.2f;
    public float enemyGenLevel = 0.3f;
    

   
    public LayerMask room;
    
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<Spawn_room>();
        es = GetComponent<EnemySpawner>();
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
                placePlatform();
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

    private void placePlatform()
    {
        //es.createEnemyList(10);
        float[,] noiseMap = new float[roomSizeX, roomSizeY];

        float seedX = Random.Range(-1000f, 1000f);
        float seedY = Random.Range(-1000f, 1000f);

        // Map noise เข้า Array
        for (int y = 0; y < roomSizeY; y ++)
        {
            for (int x = 0; x < roomSizeX; x++)
            {
                float noiseValue = Mathf.PerlinNoise(x * scale + seedX, y * scale + seedY);
                if(x == 0 || y == 0 || x == roomSizeX -1 || y == roomSizeY - 1)
                    noiseMap[x, y] = 1;
                else
                    noiseMap[x, y] = noiseValue;
            }
        }

        stepY = Random.Range( randomYRange[0], randomYRange[1] );

        // เอา noise ที่ Map ไว้มา spawn platform
        for(int y = 1; y < roomSizeY-1; y += stepY)
        {
            for (int x = 1; x < roomSizeX-1; x ++)
            {
                float noiseValue = noiseMap[x, y];

                Vector3 pos = new Vector2(x * blockScale + startX, y * blockScale - 2.75f);
                if (noiseValue < platformGenLevel && platformGenLevel > enemyGenLevel)
                {
                    GameObject placed_block = (GameObject)Instantiate(blockToPlace(
                        noiseMap[x-1, y] < platformGenLevel,
                        noiseMap[x+1, y] < platformGenLevel
                        ),transform.position + pos, Quaternion.identity);
                    placed_block.name = "block " + pos;
                    placed_block.transform.parent = GameObject.Find("platforms").transform;
                }
                
                /*else if (noiseValue < enemyGenLevel)
                {
                    es.createEnemy( pos );
                }*/
            }
        }
    }

    GameObject blockToPlace(bool left, bool right)
    {
        /*if (left && right && top && bot)
            return blockCenter;
        else if (left && right && !top || !left && !right && !top && bot)
            return blockTop;
        else if (!top && !bot)
            return oneWayPlatform;
        else if (!left && right && !top)
            return blockTopLeft;
        else if (left && !right && !top)
            return blockTopRight;
        else if (left && right && top && !bot || !left && !right && top && !bot)
            return blockBot;
        else if (left && !right && top && !bot)
            return blockBotRight;
        else if (!left && right && top && !bot)
            return blockBotLeft;
        else if (!left && right && top && bot || !left && right && !top && !bot)
            return blockLeft;
        else if (left && !right && top && bot || left && !right && !top && !bot)
            return blockRight;
        */
        if(!left && !right)
            return noBlock;
        else if (left && right)
            return blockTop;
        else if (!left && right)
            return blockTopLeft;
        else if (left && !right)
            return blockTopRight;


        return noBlock;
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

    private bool onRoom()
    {
        //Debug.Log( Physics2D.OverlapBox(transform.position, new Vector2(5, 5), 0f, room) );
        return Physics2D.OverlapBox(transform.position, new Vector2(5, 5), 0f, room);
    }

    /*private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(5, 5));

    }*/
}
