using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAi : MonoBehaviour
{
    [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 50f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float JumpNodeHeightRequirement = 0.8f;
    public float jumpForce = 300f;
    public float jumpCheckOffset = 0.1f;

    [Header("Custom Behevior")]
    public bool followEnable = true;
    public bool jumpEnable = true;
    public bool diractionLookEnable = true;

    private Path path;
    private int currentWaypoint = 0;
    Seeker seeker;
    Rigidbody2D rb;

    [Header("Animation")]
    public Animator animator;
    public bool die = false;
    public float timeToDestoryThis = 5;
    public bool dieAnimaion = false;

    private BoxCollider2D boxCollider;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);

    }

    private void FixedUpdate()
    {
        if (TargetInDistance() && followEnable)
            PathFollow();
        else
            animator.SetBool("isRunning", false);
        lockRotation();
        if(dieAnimaion)
            animator.SetTrigger("isDie");
        if (die)
        {
            timeToDestoryThis -= Time.deltaTime;
            if(timeToDestoryThis <= 0)
                Destroy(gameObject);
        }
            

    }

    private void UpdatePath()
    {
        if (followEnable && TargetInDistance() && seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    private void PathFollow()
    {
        if (path == null) {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count){
            return;
        }

        

        //isGrounded = Physics2D.Raycast(transform.position, -Vector3.up, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);
        LayerMask groundLayer = LayerMask.GetMask("Ground");
        RaycastHit2D isGrounded = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        
        //Animation set
        if(isGrounded.collider != null )
            animator.SetBool("isRunning", true);
        animator.SetBool("isJumping", (isGrounded.collider == null));

        //Calculate Direction
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        //Jump
        if( jumpEnable && isGrounded)
        {
            if(direction.y > JumpNodeHeightRequirement)
            {
                rb.AddForce(Vector2.up * jumpForce);
            }
        }

        //Move
        Vector2 pushX = new Vector2(force.x, 0);
        rb.AddForce(pushX);

        //Next Waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (diractionLookEnable)
        {
            if (rb.velocity.x > 0.05f)
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            else if(rb.velocity.x < -0.05f)
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }

    private void OnPathComplete(Path p)
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
}
