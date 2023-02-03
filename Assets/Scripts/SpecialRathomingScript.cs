using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRathomingScript : MonoBehaviour
{

    public Transform orientation;



    public Animator animator;
    public Transform target;
    public float speed;
    Rigidbody rig;
    movemen pm;

    public Transform player;
    // public float sightRange, attackRange;
    // public bool playerInSightRange, playerInAttackRange;
    public GameObject self;
    public bool cansee = false;
    // Start is called before the first frame update

    public conedetectin cd;

    [Header("Ground Check")]
    public float enemyHeight;
    public LayerMask whatIsGround;
    public bool grounded;
    public float groundDrag;
    public int dumb;

    public float moveSpeed;
    Vector3 moveDirection;

    public float force;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        pm = GetComponent<movemen>();
        player = GameObject.Find("Player").transform;
        animator = gameObject.GetComponent<Animator>();
        // animator.SetBool("PlayRun", false);

        rig.isKinematic = true;

        StartCoroutine(attackCooldown());
    }

    // Update is called onc
    // e per frame




    public void Update()
    {

        grounded = Physics.Raycast(transform.position, Vector3.down, enemyHeight * 0.5f + 0.3f, whatIsGround);
        if (grounded)
            //Debug.Log("isgrounded");
            dumb = 1;
        else
            //  Debug.Log("notntogrounded");
            rig.AddForce(0, force, 0, ForceMode.Force);



        if (cd.active == true)
        {


            rig.isKinematic = false;
            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
            moveDirection = orientation.forward;
            //make this pos.y into the ground.
 
            animator.SetBool("PlaySpecialRun", true);
            transform.LookAt(target);
            Debug.Log("movovmoemvoe");
            rig.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);


        }


        if (cd.active == false)
        {

            rig.isKinematic = true;
            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
            //   pos.y = 1f;
            // animator.SetBool("PlayRun", false);
            transform.LookAt(target);
             Debug.Log("stop");
            

        }
        // ATTACK SCRIPT
        float distance = Vector3.Distance(self.transform.position, player.transform.position);
        Debug.Log(distance);
        if(distance <= 5){
            animator.SetBool("PlayAttack", true);
            moveSpeed = 0;
           
            //Cooldown
            IEnumerator attackCooldown(){
                yield return new waitforseconds(3f);
                //my code here after 3 seconds
            }
        }
        if(distance > 5){
            animator.SetBool("PlayAttack", false);
        }

    }













}

