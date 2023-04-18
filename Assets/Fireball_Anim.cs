using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Anim : MonoBehaviour
{
    public void DestroyMe()
    {
        Destroy(transform.root.gameObject);
    }
}
