using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class BossFollowPlayerML : Agent
{
    #region Variable
    [Header("Movement")]
    [SerializeField] private Transform target;
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    public LayerMask groundLayer;

    [Header("Animator")]
    public Animator animator;

    private BoxCollider2D boxCollider;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        /* Debug.Log("A[0] : " + actions.DiscreteActions[0]);
        Debug.Log("A[1] : " + actions.DiscreteActions[1]); */

        /*
            Data Used
        ContinuousActions[0] : move X
        
        DiscreteActions[0] : for jump decision
        DiscreteActions[1] : for att decision

         */

        run(actions.ContinuousActions[0]); 
        jump(actions.DiscreteActions[0]);
        actionToDo(actions.DiscreteActions[1]);

        //Debug.Log(actions.DiscreteActions[1]);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(target.position);
    }

    void jump(int jump)
    {
        if (jump == 1 && isGrounded())
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    void run(float moveX)
    {
        rb.velocity = new Vector2(moveX * speed * Time.deltaTime, rb.velocity.y);
        if (rb.velocity.x > 0.05f)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (rb.velocity.x < -0.05f)
            transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        //Debug.Log(moveX);
    }

    void actionToDo(int action)
    {
        if (action == 0)
            animator.SetTrigger("attack1");
        else if (action == 1)
            animator.SetTrigger("attack2");
        else if (action == 2)
            animator.SetTrigger("attack3");
        else if (action == 3)
            animator.SetTrigger("block");
        else if (action == 4)
            animator.SetTrigger("roll");
    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector2(Random.Range(-6f,7.5f), Random.Range(-2f,4));
        target.localPosition = new Vector2(Random.Range(-6f,7.5f), Random.Range(-2f,4));
        Debug.Log("New Ep Begin");
        SetReward(-100);
    }
}
