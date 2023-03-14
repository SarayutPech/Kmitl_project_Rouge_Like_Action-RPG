using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public IList<GameObject> groupOfEnemy;
    [Header("Castle Enemy Type")]
    [SerializeField] private GameObject[] CastleEnemyGround;
    [SerializeField] private GameObject[] CastleEnemyFly;
    [SerializeField] private GameObject[] CastleEnemyRange;

    [Header("Neon Enemy Type")]
    [SerializeField] private GameObject[] NeonEnemyGround;
    [SerializeField] private GameObject[] NeonEnemyFly;
    [SerializeField] private GameObject[] NeonEnemyRange;

    [Header("Pirate Enemy Type")]
    [SerializeField] private GameObject[] PirateEnemyGround;
    [SerializeField] private GameObject[] PirateEnemyFly;
    [SerializeField] private GameObject[] PirateEnemyRange;

    [Header("Enemy Spawn Property")]
    [SerializeField] private LayerMask ground;
    [SerializeField] private int enemyToSpawnLeft;

    [Header("Agent Property")]
    [SerializeField] private float stepX = 10;
    [SerializeField] private float stepY = 10;
    [SerializeField] private float scale = 0.5f;
    [SerializeField] private float startX = 0.5f;
    [SerializeField] private float startY = 0.5f;
    [SerializeField] private float space = 0.25f;

    private LevelManagerParameter levelManagerParameter;
    public int biome;
    public LayerMask room;

    public List<Vector3> canSpawn = new List<Vector3>();
    private void Awake()
    {    
        levelManagerParameter = GetComponent<LevelManagerParameter>();
    }
    private void Start()
    {
        enemyToSpawnLeft = levelManagerParameter.enemyPerWave;
    }

    public enum EnemyType
    {
        ground,
        fly,
        range
    }

    private GameObject AddEnemy(EnemyType type)
    {
        int rand;
        GameObject result = null;
        if(biome == 0)
        {
            switch (type)
            {
                case EnemyType.ground:
                    rand = Random.Range(0, CastleEnemyGround.Length);
                    result = CastleEnemyGround[rand];
                    break;
                case EnemyType.fly:
                    rand = Random.Range(0, CastleEnemyFly.Length);
                    result = CastleEnemyFly[rand];
                    break;
                case EnemyType.range:
                    rand = Random.Range(0, CastleEnemyRange.Length);
                    result = CastleEnemyRange[rand];
                    break;
            }
        }
        else if (biome == 1)
        {
            switch (type)
            {
                case EnemyType.ground:
                    rand = Random.Range(0, NeonEnemyGround.Length);
                    result = NeonEnemyGround[rand];
                    break;
                case EnemyType.fly:
                    rand = Random.Range(0, NeonEnemyFly.Length);
                    result = NeonEnemyFly[rand];
                    break;
                case EnemyType.range:
                    rand = Random.Range(0, NeonEnemyRange.Length);
                    result = NeonEnemyRange[rand];
                    break;
            }
        }
        else if (biome == 2)
        {
            switch (type)
            {
                case EnemyType.ground:
                    rand = Random.Range(0, PirateEnemyGround.Length);
                    result = PirateEnemyGround[rand];
                    break;
                case EnemyType.fly:
                    rand = Random.Range(0, PirateEnemyFly.Length);
                    result = PirateEnemyFly[rand];
                    break;
                case EnemyType.range:
                    rand = Random.Range(0, PirateEnemyRange.Length);
                    result = PirateEnemyRange[rand];
                    break;
            }
        }

        return result;
    }

    private EnemyType randType()
    {
        EnemyType result = EnemyType.ground;
        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                result = EnemyType.ground;
                break;
            case 1:
                result = EnemyType.fly;
                break;
            case 2:
                result = EnemyType.range;
                break;
        }
        return result;
    }

    public void createEnemyList(int amount)
    {
        IList<GameObject> result = new List<GameObject>();
        EnemyType enemyType;
        for(int i = 0; i < amount; i++)
        {
            enemyType = randType();
            result.Add(AddEnemy(enemyType));
        }

        groupOfEnemy = result;

        foreach (GameObject name in groupOfEnemy)
        {
            Debug.Log(name.name);
        }
    }

    public void createEnemy(Vector3 pos)
    {
        if(enemyToSpawnLeft > 0)
        {
            EnemyType enemyType;
            enemyType = randType();
            Instantiate(AddEnemy(enemyType), transform.position + pos, Quaternion.identity);
            enemyToSpawnLeft--;
        }
    }

    public void canEnemySpawn()
    {
        canSpawn.Clear();
        getBiome();

        for (float y = 0; y < stepY; y += scale)
        {
            y += space;
            for (float x = 0; x < stepX; x += scale)
            {
                x += space;
                Vector3 pos = new Vector2(x - startX, y - startY);
                Collider2D block = Physics2D.OverlapBox(transform.position + pos, new Vector2(scale, scale), 0, ground);
                if(!block)
                {
                    //Debug.Log("can spawn");
                    canSpawn.Add(pos);
                }     
            }
        }

        while(enemyToSpawnLeft > 0)
        {
            int rand = Random.Range(0, canSpawn.Count);
            createEnemy(canSpawn[rand]);
            //Debug.Log("Spawn at : " + canSpawn[rand] + " by " + rand);
            canSpawn.RemoveAt(rand);
        }

        //Debug.Log(canSpawn.Count);
        enemyToSpawnLeft = levelManagerParameter.enemyPerWave;
    }
    
    public void OnDrawGizmos()
    {
        for (float y = 0; y < stepY; y += scale)
        {
            y += space;
            for (float x = 0; x < stepX; x += scale)
            {
                x += space;
                Vector3 pos = new Vector2(x - startX , y - startY);
                Collider2D block = Physics2D.OverlapBox(transform.position + pos, new Vector2(scale, scale), 0, ground);
                if (!block)
                {
                    Gizmos.color = Color.blue;
                }
                else
                    Gizmos.color = Color.yellow;
                
                Gizmos.DrawWireCube(transform.position + pos, new Vector2(scale, scale));
            }
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
}
