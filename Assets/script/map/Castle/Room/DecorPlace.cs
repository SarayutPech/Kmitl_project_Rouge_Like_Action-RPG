using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorPlace : MonoBehaviour
{
    [Header("Agent Property")]
    [SerializeField] private float stepX = 10;
    [SerializeField] private float stepY = 10;
    [SerializeField] private float scale = 0.5f;
    [SerializeField] private float startX = 0.5f;
    [SerializeField] private float startY = 0.5f;
    [SerializeField] private float space = 0.25f;
    [SerializeField] private LayerMask ground;

    public void OnDrawGizmos()
    {
        for (float y = 0; y < stepY; y += scale)
        {
            y += space;
            for (float x = 0; x < stepX; x += scale)
            {
                x += space;
                Vector3 pos = new Vector2(x - startX, y - startY);
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
