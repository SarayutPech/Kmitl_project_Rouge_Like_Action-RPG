using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public int dmg;
    public float lifeTime;
    public Vector3 dir;

    // Update is called once per frame
    void Update()
    {
        if (lifeTime >= 0)
        {
            move(dir);
;           lifeTime -= Time.deltaTime;
        }
        else
            Destroy(gameObject);
    }

    public void move(Vector3 dir)
    {
        transform.position = transform.position + dir * Time.deltaTime;
    }
}
