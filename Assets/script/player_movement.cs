using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float speed = 40f;
    public float jumpforce = 5f;
    private Rigidbody2D rb;
    public Animator animator;

    private bool facingRight = true;
    public ParticleSystem dust;

    public Transform feetpos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        lockRotation();
        running();
        jumping();
    }

    void Flip()
    {
        CreateDust();
        transform.Rotate(0f, 180f, 0f);

        facingRight = !facingRight;
    }

    void CreateDust()
    {
        dust.Play();
    }

    void running()
    {
        animator.SetFloat("run", 0);
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
        if (Input.GetAxisRaw("Horizontal") != 0 )
        {
            
            animator.SetFloat("run", 1);
            if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight)
            {
                Flip();
            }

            if (Input.GetAxisRaw("Horizontal") < 0 && facingRight)
            {
                Flip();
            }
        }
    }

    void jumping()
    {
        isGrounded = Physics2D.OverlapCircle(feetpos.position,checkRadius,whatIsGround);
        
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isGrounded = false;
            animator.SetTrigger("takeoff");
            rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            //Debug.Log("Jump !");
        }

        if(isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }

    }

    void lockRotation()
    {
        transform.eulerAngles = new Vector3(
        0,
        transform.eulerAngles.y,
        0
);
    }
}
