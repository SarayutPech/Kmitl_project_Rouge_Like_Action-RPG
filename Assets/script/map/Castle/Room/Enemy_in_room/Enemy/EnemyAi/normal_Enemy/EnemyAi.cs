using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAi : MonoBehaviour
{
    #region Variable
    [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 50f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float JumpNodeHeightRequirement = 0.8f;
    public float jumpforce = 5f;
    public float jumpCheckOffset = 0.1f;

    [Header("Custom Behevior")]
    public bool followEnable = true;
    public bool jumpEnable = true;
    public bool diractionLookEnable = true;
    public bool canFly = false;

    private Path path;
    private int currentWaypoint = 0;
    Seeker seeker;
    Rigidbody2D rb;

    [Header("Animation")]
    public Animator animator;
    public bool LockRotate = true;

    

    private BoxCollider2D boxCollider;
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gameObject.transform.position, activateDistance);
    }

    private void Start()
    {   
        //GetComponent
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        //find player position
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //AI path setup
        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);

    }

    public void UpdatePath()
    {
        if (followEnable && TargetInDistance() && seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }


    //stop_chase_at : distance of player and enemy
    public void PathFollow(float speed, float stop_chase_at = -1, string moveingStage = "isRunning")
    {
        if (path == null) {
            animator.SetBool(moveingStage, false);
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count){
            animator.SetBool(moveingStage, false);
            return;
        }

        if (Vector2.Distance(transform.position, target.position) <= stop_chase_at && Vector2.Distance(transform.position, target.position) > -0.0001)
        {
            rb.velocity = new Vector2(rb.velocity.x / 2, rb.velocity.y / 2);
            animator.SetBool(moveingStage, false);
            return;
        }

        //On Ground Check
        //isGrounded = Physics2D.Raycast(transform.position, -Vector3.up, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);
        LayerMask groundLayer = LayerMask.GetMask("Ground");
        RaycastHit2D isGrounded = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);


        //Animation set
        if (isGrounded.collider != null )
            animator.SetBool(moveingStage, true);
        if (jumpEnable)
            animator.SetBool("isJumping", (isGrounded.collider == null));

        //Calculate Direction
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        //Jump
        if( jumpEnable && isGrounded)
        {
            if(direction.y > JumpNodeHeightRequirement)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            }
        }

        //Move
        Vector2 pushX = new Vector2(force.x, 0);
        if (!canFly)
            rb.AddForce(pushX);
        else
            rb.AddForce(force);

        //Next Waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        //Flip Sprite
        if (diractionLookEnable)
        {
            if (rb.velocity.x > 0.05f)
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            else if(rb.velocity.x < -0.05f)
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    public bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) <= activateDistance;
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void lockRotation()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    private void Update()
    {
        if (LockRotate)
            lockRotation();

        if (jumpEnable)
        {
            try
            {
                LayerMask groundLayer = LayerMask.GetMask("Ground");
                RaycastHit2D isGrounded = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

                if (isGrounded.collider != null)
                    animator.SetBool("isJumping", false);
                else
                    animator.SetBool("isJumping", true);
            }
            catch
            {
                
            }
        }
    }

    
}
