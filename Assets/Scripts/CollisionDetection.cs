using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wp;
    public GameObject HitParticle;
    public EnemyHealth eh;

    // private void OnTriggerEnter(Collider other)
    //  {

    //    if(other.tag == "Enemy"&& wp.isAttacking)
    //    {


    //        eh.AddjustCurrentHealth(-1);
    //    }


    //   }


    void OnCollisionEnter(Collision collision)
    {

          if (collision.gameObject.tag == "Enemy")
          {

             print("SwordHit");
          
            eh.AddjustCurrentHealth(-1);

           EnemyHealth EnemyHealth = collision

        }

       

    }
}
