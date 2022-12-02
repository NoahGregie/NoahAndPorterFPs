using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wp;
    public GameObject HitParticle;
    public EnemyHealth eh;
    public ratOgreHealth rh;
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
             eh= collision.gameObject.GetComponent<EnemyHealth>();
             eh.AddjustCurrentHealth(-1);



        }
         if(collision.gameObject.tag == "BigEnemy")
        {

            rh = collision.gameObject.GetComponent<ratOgreHealth>();
            rh.AddjustCurrentHealth(-1);

        }



      }

   



}
