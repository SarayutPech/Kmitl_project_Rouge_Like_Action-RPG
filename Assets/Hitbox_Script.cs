using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox_Script : MonoBehaviour
{

    public float activateDistance;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gameObject.transform.position, activateDistance);
    }
}
