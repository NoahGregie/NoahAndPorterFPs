using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AdvancdedEnemyAI : MonoBehaviour
{

    [Header("Stats")]
    public int health;


   public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    private void Awake()
    {

        player = GameObject.Find("Player").transform;
       agent = GetComponent<NavMeshAgent>();


    }
    private void Update()
    {
        //check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);


      
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

   private void Patroling()
  {
        if (!walkPointSet) SearchWalkPoint();
       if(walkPointSet)
       {
           agent.SetDestination(walkPoint);

            Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //    walkpointreached
            if (distanceToWalkPoint.magnitude < 1f)
                walkPointSet = false;

       }
   }
    private void SearchWalkPoint()
    {
        //calculate random point
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {

        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //make sure enemy doesnt move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {

            //attack code
           

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }


      
    }

    public void TakeDamage(int damage)
    {

        health -= damage;

        if (health <= 0)
            Destroy(gameObject);

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;

    }


}
