using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class movemen : MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float slideSpeed;

    private float desiredMoveSpeed;
    private float lastDeseriedMoveSpeed;


  

    public float groundDrag;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;


    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.C;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopehit;
    private bool exitingBool;

    [Header("Timer")]

    public bool TimerIsRunning = false;
    public float timeRemaining = 10f;

    [Header("RandomStuff")]
    public Transform orientation;
   
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;

    public bool crouch;

    FillCode fc;
    public GameObject Fill;


    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        sliding,
        air

    }

    public bool sliding;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        
        startYScale = transform.localScale.y;
      
    }

    private void Update()
    {
       
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
      
        MyInput();
        SpeedControl();
        StateHandler();
        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
        //no clip
       

        if(TimerIsRunning)
        {

            if(timeRemaining > 0)
            {

                timeRemaining -= Time.deltaTime;
                Debug.Log(timeRemaining);

            }
            else
            {
                Debug.Log("Timerdone");
                TimerIsRunning = false;
            }



        }




    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
   

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        fc = Fill.GetComponent < FillCode>();
        // when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        //start crouching
        if (Input.GetKeyDown(crouchKey))
        {

            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            crouch = true;
            TimerIsRunning = true;
            



        }
        //stop crouch
        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x,startYScale, transform.localScale.z);
            TimerIsRunning = false;
            crouch = false;

        }
        if(fc.isDone == true)
        {
            Debug.Log("dog");
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
            TimerIsRunning = false;
            crouch = false;

        }







    }


    private void StateHandler()
    {
        //slding
        if (sliding)
        {
            state = MovementState.sliding;
            moveSpeed = slideSpeed;
          

        }


        //crouchiung
       else if (Input.GetKey(crouchKey))
        {

            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
            
        }

        //move-Sprinting
       else if (grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
           
        }

        //walking
        else if (grounded)
        {

            state = MovementState.walking;
            moveSpeed = walkSpeed;
            
        }
        //air
        else
        {
            state = MovementState.air;
            
        }

    }

    private void MovePlayer()
    {

        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on slope
        if (onSlope() && !exitingBool)
        {
            rb.AddForce(getSlopeMovementDirection() * moveSpeed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);

        }

        // on ground
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        //turn gravity off while on slope
        rb.useGravity = !onSlope();
    }

    private void SpeedControl()
    {
        //limiting spped on slope
        if (onSlope() && !exitingBool)
        {
            if (rb.velocity.magnitude > moveSpeed)
                rb.velocity = rb.velocity.normalized * moveSpeed;

        }
        //limiting sepped on ground or in air
        else
        {
            Vector3 flatvel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            //limit veclocity if needed
            if(flatvel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatvel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {


        exitingBool = true;
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
        exitingBool = false;
    }

    private bool onSlope()
    {

        if(Physics.Raycast(transform.position, Vector3.down, out slopehit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopehit.normal);
            return angle < maxSlopeAngle && angle != 0;


        }
        return false;

    }

    private Vector3 getSlopeMovementDirection()
    {

        return Vector3.ProjectOnPlane(moveDirection, slopehit.normal).normalized;

    }

}