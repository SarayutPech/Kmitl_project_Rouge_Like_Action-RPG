using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    [SerializeField] private float speed = 40f;
    [SerializeField] private float jumpforce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] GameObject poweJumpskillObj;
    public float knockbackTime = 0;

    public Animator animator;
    

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private float DirIn;

    //public float move_speed;
    // Skill Animator 
    public Animator auraAnimator;
    //Skill DoubleJump
    private bool canDoubleJump = false;
    private bool doubleJump;   
    //private float doubleJumpForce= 2f;

    //Skill Dash
    private bool canDash = true;
    private bool isDash;
    //private int dashCharge = 1;
    private float dashForce = 5f;
    private float dashTime = 0.2f;
    private float dashCooldown = 1f;

    // Skill Power Jump
    public bool powerJumpisActive;

    public PlayerStats charaStat;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        auraAnimator = GameObject.FindGameObjectWithTag("Animator_Aura").GetComponent<Animator>();
        charaStat = GetComponent<PlayerStats>();
    }
    private void Update()
    {
        DirIn = Input.GetAxisRaw("Horizontal");
        lockRotation();
        animator.SetBool("jumping", !isGrounded());

       
        //Jumping
        if (isGrounded() && !Input.GetKey(KeyCode.Space))
        {
            doubleJump = false;
           
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping();
            
        }

        // Dash Skill
        if (isDash)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
           
            StartCoroutine(Dash());
        }
            
            

        running();

        if(knockbackTime > 0)
            knockbackTime -= Time.deltaTime;
        //Debug.Log("rb.velocity : " + rb.velocity);
    }
    void running()
    {
        float move_speed = speed * (1 + ((float)charaStat.moveSpeed.GetValue() / 100));
        //Debug.Log((1 + ((float)charaStat.moveSpeed.GetValue() / 100)));
        //transform.position += new Vector3(DirIn, 0, 0) * Time.deltaTime * speed;
        if (knockbackTime <= 0)           
            rb.velocity = new Vector2(DirIn * move_speed, rb.velocity.y);
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

        float jumpPower = jumpforce * (1f + (0.5f*((float)charaStat.moveSpeed.GetValue() / 100)));
        if (isGrounded() && !onWall())
        {

            PowerJump(powerJumpisActive); // active skill
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

            if (canDoubleJump)
            {
                doubleJump = true;
                Debug.Log(doubleJump);
            }
            
        }
        else if (!isGrounded() && onWall())
        {
            animator.SetBool("jumping", false);
            rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, jumpPower);
        }
        else if (doubleJump)
        {
            PowerJump(powerJumpisActive); // active skill
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            doubleJump = false;
            Debug.Log(doubleJump);
        }
        /* else if (!isGrounded() && !onWall() && doubleJump == true && isjump == true)
         {

             isjump = false;          
         }*/
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f ,groundLayer);
        return raycastHit.collider != null;
    }



    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size , 0, new Vector2(-transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }


    void lockRotation()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

   

    // Skill

    public void PowerJump(bool isActive)
    {
        if (isActive)
        {
            
            Vector3 playerTrans = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 pos = new Vector3(0.0f, 0.1f, 0.0f);
            Instantiate(poweJumpskillObj, playerTrans-pos, Quaternion.identity);
            Debug.Log("Power Jump!!!");
            //auraAnimator.SetTrigger("PowerJump");
            //.......

        }
       
    }

    public void SetDoubleJump(bool isdbJump)
    {
        canDoubleJump = isdbJump;
    }


    public void SetDash(bool isdash)
    {
        canDash = isdash;
    }

    IEnumerator Dash()
    {
        canDash = false;
        isDash = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashForce, 0f);

        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = originalGravity;
        isDash = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        Debug.Log("dash");
    }
}
