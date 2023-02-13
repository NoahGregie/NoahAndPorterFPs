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


    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {

            print("SwordHit");
            eh = other.gameObject.GetComponent<EnemyHealth>();
            eh.AddjustCurrentHealth(-1);
            Instantiate(HitParticle, transform.position, transform.rotation);


        }
        if (other.gameObject.tag == "BigEnemy")
        {

            rh = other.gameObject.GetComponent<ratOgreHealth>();
            rh.AddjustCurrentHealth(-1);

        }





    }






}
