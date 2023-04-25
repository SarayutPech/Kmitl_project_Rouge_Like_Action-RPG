using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScaner : MonoBehaviour
{
    public GameObject GateL, GateR;
    public Vector3 size;
    public LayerMask Enemy;

    private void Update()
    {
        Collider2D enemyCol = Physics2D.OverlapBox(transform.position, size, 0f, Enemy);
        //Debug.Log(enemyCol);
        if (enemyCol != null)
            setGate(true);
        else
            setGate(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position,size);
    }

    void setGate(bool status)
    {
        GateL.SetActive(status);
        GateR.SetActive(status);
    }
}
