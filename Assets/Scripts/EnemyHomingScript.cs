using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomingScript : MonoBehaviour
{

    public Animator animator;
    public Transform target;
    public float speed;
    Rigidbody rig;
    movemen pm;
    public LayerMask whatIsGround, whatIsPlayer;
    public Transform player;
   // public float sightRange, attackRange;
   // public bool playerInSightRange, playerInAttackRange;
    public GameObject self;
    public bool cansee = false;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        pm = GetComponent<movemen>();
        player = GameObject.Find("Player").transform;
        animator = gameObject.GetComponent<Animator>();
       // animator.SetBool("PlayRun", false);

    }

    // Update is called onc
    // e per frame

    private void Update()
    {

       
    }




    void FixedUpdate()


    {
       
        
            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
            // pos.y = 1f;
            animator.SetBool("PlayRun", true);
            transform.LookAt(target);

            rig.MovePosition(pos);

        

    }


   
}

