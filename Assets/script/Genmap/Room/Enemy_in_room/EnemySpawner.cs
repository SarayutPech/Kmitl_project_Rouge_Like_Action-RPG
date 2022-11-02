using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public IList<GameObject> groupOfEnemy;
    [Header("Enemy Type")]
    [SerializeField] private GameObject[] enemyGround;
    [SerializeField] private GameObject[] enemyFly;
    [SerializeField] private GameObject[] enemyRange;

    [Header("Enemy Spawn Property")]
    [SerializeField] private LayerMask ground;
    [SerializeField] private int enemyPerWave = 10;
    [SerializeField] private int enemyToSpawnLeft = 10;

    [Header("Agent Property")]
    [SerializeField] private float stepX = 10;
    [SerializeField] private float stepY = 10;
    [SerializeField] private float scale = 0.5f;
    [SerializeField] private float startX = 0.5f;
    [SerializeField] private float startY = 0.5f;
    [SerializeField] private float space = 0.25f;

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
        switch (type)
        {
            case EnemyType.ground:
                rand = Random.Range(0, enemyGround.Length);
                result = enemyGround[rand];
                break;
            case EnemyType.fly:
                rand = Random.Range(0, enemyFly.Length);
                result = enemyFly[rand];
                break;
            case EnemyType.range:
                rand = Random.Range(0, enemyRange.Length);
                result = enemyRange[rand];
                break;     
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
        EnemyType enemyType;
        enemyType = randType();
        Instantiate(AddEnemy(enemyType), transform.position + pos, Quaternion.identity);
        enemyToSpawnLeft--;
    }

    public void canEnemySpawn()
    {
        for (float y = 0; y < stepY; y += scale)
        {
            y += space;
            for (float x = 0; x < stepX; x += scale)
            {
                x += space;
                Vector3 pos = new Vector2(x - startX, y - startY);
                Collider2D block = Physics2D.OverlapBox(transform.position + pos, new Vector2(2.5f, 2.5f), 0, ground);
                if(!block && enemyToSpawnLeft > 0)
                {
                    Debug.Log("can spawn");
                    int rand = Random.Range(0, 10);
                    if(rand > 6)
                    {
                        createEnemy(pos);
                        x += scale * 5;
                    }
                }else
                    Debug.Log("can't spawn");
                    
            }
            
        }

        enemyToSpawnLeft = enemyPerWave;
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
                    Gizmos.color = Color.green;
                }
                else
                    Gizmos.color = Color.red;
                
                Gizmos.DrawWireCube(transform.position + pos, new Vector2(scale, scale));
            }
        }
    }

}
