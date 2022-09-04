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
    [SerializeField] private bool die = false;
    public float timeToDestoryThis = 5;
    private bool inAttackRange = false;
    public bool LockRotate = true;

    private BoxCollider2D boxCollider;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);

    }
    private void Update()
    {
        if(LockRotate)
            lockRotation();   
    }
    private void FixedUpdate()
    {
        if (TargetInDistance() && followEnable)
            PathFollow();
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", false);
        }

        if (die)
            enemydie();

    }
    private void enemydie()
    {
        if (timeToDestoryThis >= 5)
        {
            animator.SetTrigger("isDie");
            followEnable = false;
        }
        timeToDestoryThis -= Time.deltaTime;
        if (timeToDestoryThis <= 0)
            Destroy(gameObject);
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

        
        //On Ground Check
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

    private void attack()
    {
        animator.SetTrigger("attack");
    }

    
}
