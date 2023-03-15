using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingScript : MonoBehaviour
{

    public Transform orientation;

    public LayerMask whatIsGround, whatIsPlayer;

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


    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

 

    [Header("Ground Check")]
    public float enemyHeight;
  
    public bool grounded;
    public float groundDrag;
    public int dumb;

    public float moveSpeed;
    Vector3 moveDirection;

    public float force;

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public float gernadespeed; 
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        pm = GetComponent<movemen>();
        player = GameObject.Find("playerOBJ").transform;
        animator = gameObject.GetComponent<Animator>();
        // animator.SetBool("PlayRun", false);

        rig.isKinematic = true;
    }

    // Update is called onc
    // e per frame




    public void Update()
    {



        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);



        if (playerInSightRange && !playerInAttackRange)
        {


            ChasePlayer();
           // Debug.Log("j");
        }


        
        if (playerInAttackRange && playerInSightRange) AttackPlayer();


        grounded = Physics.Raycast(transform.position, Vector3.down, enemyHeight * 0.5f + 0.3f, whatIsGround);
        if (grounded)
            //Debug.Log("isgrounded");
            dumb = 1;
        else
            //  Debug.Log("notntogrounded");
            rig.AddForce(0, force, 0, ForceMode.Force);



      

        




    }




    private void ChasePlayer()
    {
        transform.LookAt(target);
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        transform.position=(pos);
        animator.SetBool("PlayRun", true);
    }



    private void AttackPlayer()
    {

        animator.SetBool("PlayShoot", true);
        transform.LookAt(player);


        if (!alreadyAttacked)
        {

            //attack code
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * gernadespeed, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }


    }




    private void ResetAttack()
    {
        alreadyAttacked = false;

    }


}

