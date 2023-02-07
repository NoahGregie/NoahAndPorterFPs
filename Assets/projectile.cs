using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public PlayerHealth ph;



    private void OnCollisionEnter(Collision collision)
    {
       

        if (collision.gameObject.tag == "Player")
        {

            //Debug.Log("salami");
            ph = collision.gameObject.GetComponent<PlayerHealth>();
            ph.TakeDamage(1);



        }




    }







}

 



   

