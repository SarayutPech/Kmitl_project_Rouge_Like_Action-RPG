using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField] private float TimeToDestroy = 1;
    [SerializeField] private float radius = 1;
    [SerializeField] private LayerMask player;
    public int dmg;
    
    private LevelManagerParameter levelManagerParameter;
    private void Awake()
    {
        levelManagerParameter = GameObject.Find("level manager").GetComponent<LevelManagerParameter>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeToDestroy -= Time.deltaTime;
        if(TimeToDestroy <= 0)
        {
            Collider2D playerCol = Physics2D.OverlapCircle(gameObject.transform.position, radius, player);
            if (playerCol)
            {
                Debug.Log("Hit !");
                playerCol.GetComponent<CharacterStats>().TakeDamage(dmg - levelManagerParameter.DmgBuffer);
            }
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gameObject.transform.position, radius);
    }
}
