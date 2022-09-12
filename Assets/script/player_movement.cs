using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    [SerializeField] private float speed = 40f;
    [SerializeField] private float jumpforce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    public Animator animator;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private float DirIn;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        DirIn = Input.GetAxisRaw("Horizontal");
        lockRotation();
        animator.SetBool("jumping", !isGrounded());


        if (Input.GetKey(KeyCode.Space))
            jumping();

        running();
       // Debug.Log("rb.velocity : " + rb.velocity);
    }
    void running()
    {
        
        
        //transform.position += new Vector3(DirIn, 0, 0) * Time.deltaTime * speed;
        rb.velocity = new Vector2(DirIn * speed, rb.velocity.y);
        //rb.AddForce(Vector2.right * DirIn * speed);

        // fliping
        if (DirIn != 0 )
        {
            animator.SetBool("running", true);
            if (DirIn > 0.1)
                transform.localScale = new Vector3(1.4f, 1.4f, 1);
            else if (DirIn < 0.1)
                transform.localScale = new Vector3(-1.4f,1.4f, 1);
        }else
        animator.SetBool("running", false);
    }

    void jumping()
    {
        if (isGrounded() && !onWall())
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        else if (!isGrounded() && onWall())
        {
            animator.SetBool("jumping", false);
            rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, jumpforce);
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f ,groundLayer);
        return raycastHit.collider != null;
    }



    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(-transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    void lockRotation()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
