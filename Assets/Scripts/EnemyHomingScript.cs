using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomingScript : MonoBehaviour
{

    public Transform target;
    public float speed;
    Rigidbody rig;
    movemen pm;
    public LayerMask whatIsGround, whatIsPlayer;
    public Transform player;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        pm = GetComponent<movemen>();
        player = GameObject.Find("Player").transform;
    
    }

    // Update is called onc
    // e per frame

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        Activation();
    }




    void FixedUpdate()


    {
       
      

        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        pos.y = 1f;

        transform.LookAt(target);

          rig.MovePosition(pos);

    

    }


    private void Activation()
    {

        if (playerInSightRange)
        {
            self.SetActive(true);
        }




    }
}

