using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidItemController : MonoBehaviour
{

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Rigidbody2D m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            m_Rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
          
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
        // return true;
    }
}
