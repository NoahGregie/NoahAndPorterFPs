using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    public LayerMask whatIsGround, whatIsPlayer;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public GameObject varGameObject;

    public GameObject var2GameObject;

    void Start()
    { 


    varGameObject.GetComponent<EnemyHomingScript>().enabled = false;
        var2GameObject.GetComponent<EnemyHealth>().enabled = false;




    }












    // Update is called once per frame
    void Update()
    {


        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        activate();
    }



private void activate ()
{

    if (playerInSightRange)
    {

        varGameObject.GetComponent<EnemyHomingScript>().enabled = true;
            var2GameObject.GetComponent<EnemyHealth>().enabled = true;
        }




}

}