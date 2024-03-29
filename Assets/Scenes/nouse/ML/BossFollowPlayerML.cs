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

    public float time;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        /*
        if(time >= 50)
            endEp("Time");
        */
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        run(actions.DiscreteActions[2]); 
        jump(actions.DiscreteActions[0]);
        actionToDo(actions.DiscreteActions[1]);

        
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
        int dir;
        if (moveX == 0)
            dir = -1;
        else
            dir = 1;

        rb.velocity = new Vector2(dir * speed * Time.deltaTime, rb.velocity.y);
        if (rb.velocity.x > 0.05f)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (rb.velocity.x < -0.05f)
            transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
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

    /*
    private float calculateReward(Transform Obj1, Transform Obj2)
    {
        float distance = Mathf.Abs(Obj1.transform.position.x - Obj2.transform.position.x) + Mathf.Abs(Obj1.transform.position.y - Obj2.transform.position.y);
        float rewardPoint = -1/ (distance * Mathf.Pow(0.9f, time));
        return rewardPoint;
    }
    */

    private float calculateReward()
    {
        float rewardPoint = Mathf.Pow(0.9f, time);
        return rewardPoint;
    }


    public override void OnEpisodeBegin()
    {
        //transform.localPosition = new Vector2(Random.Range(-7.5f,7.5f), Random.Range(-5.5f, 0f));
        transform.localPosition = new Vector2(Random.Range(-6f,6f), Random.Range(-2.5f, -0.5f));
        target.localPosition = new Vector2(Random.Range(-6f, 6f), Random.Range(-2.5f, -0.5f));
        //target.localPosition = new Vector2(0, 0);
        SetReward(0);
        time = 0;
    }

    public void endEp(string EndBy)
    {
        AddReward(calculateReward());
        float reward = GetCumulativeReward();
        Debug.Log("Ended Ep By " + EndBy + " => Reward : " + reward + " => Time : " + time);
        
        EndEpisode();
    }
}
