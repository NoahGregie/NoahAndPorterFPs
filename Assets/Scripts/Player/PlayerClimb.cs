using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    [Header("Refrences")]
    public Transform orientation;
    public Rigidbody rb;
    public movemen pm;
    public LayerMask whatIsWall;

    [Header("Climbing")]
    public float climbSpeed;
    public float maxClimbTime;
    private float climbTimer;

    private bool climbing;

    [Header("Detection")]
    public float detectionLength;
    public float sphereCastRadius;
    public float maxWallLookAngle;
    private float wallLookAngle;

    private RaycastHit frontWallHit;
    private bool wallFront;


    private void Update()
    {

        WallCheck();
        StateMachine();

        if (climbing) ClimbingMovement();



    }

    private void StateMachine()
    {
        //state1-climing
        if (wallFront && Input.GetKey(KeyCode.W) && wallLookAngle < maxWallLookAngle)
        {

            if (!climbing && climbTimer > 0) StartClimbing();
            //timer
            if (climbTimer > 0) climbTimer -= Time.deltaTime;
            if (climbTimer < 0) StopClimbing();
        }
        //state 3 none
        else
        {
            if (climbing) StopClimbing();

        }




    }

    private void WallCheck()
    {

        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out frontWallHit, detectionLength, whatIsWall);
        wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);
        if (pm.grounded)
        {
            climbTimer = maxClimbTime;

        }
    }

    private void StartClimbing()
    {
        climbing = true;

    }



    private void ClimbingMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);


    }

    private void StopClimbing()
    {
        climbing = false;



    }




}
