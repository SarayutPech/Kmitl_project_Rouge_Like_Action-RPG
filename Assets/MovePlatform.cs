using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Vector3 Col;
    public Vector3 pos;
    public LayerMask PCG_OB;
    public LayerMask DestroyLayer;
    public int dir;

    // Update is called once per frame
    void Update()
    {
        Collider2D SameOb = Physics2D.OverlapBox(transform.position + pos, Col, 0f, PCG_OB);
        if (SameOb)
        {
            Debug.Log("ASDFFFF");
            switch (dir) {
                case 0:
                    transform.position += new Vector3(-0.5f, 0.5f, 0);
                    break;
                case 1:
                    transform.position += new Vector3(0.5f, 0.5f, 0);
                    break;
                case 2:
                    transform.position += new Vector3(-0.5f, -0.5f, 0);
                    break;
                case 3:
                    transform.position += new Vector3(0.5f, -0.5f, 0);
                    break;
            }

            AstarPath.active.Scan();
        }

        Collider2D DestroyMe = Physics2D.OverlapBox(transform.position + pos, Col, 0f, DestroyLayer);
        if (DestroyMe)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + pos, Col);
    }

}
