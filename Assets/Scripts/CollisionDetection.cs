using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wp;
    public GameObject HitParticle;
    public EnemyHealth eh;
    public ratOgreHealth rh;
    public int sworddamage;
    
    // private void OnTriggerEnter(Collider other)
    //  {

    //    if(other.tag == "Enemy"&& wp.isAttacking)
    //    {


    //        eh.AddjustCurrentHealth(-1);
    //    }


    //   }


    
    private void OnTriggerEnter(Collider other)
    {
        sworddamage = -50;
        //Debug.Log("Code ACTIVATED");
        if (other.gameObject.tag == "Enemy")
        {

            print("SwordHit");
            eh = other.gameObject.GetComponent<EnemyHealth>();
            eh.AddjustCurrentHealth(sworddamage);
            Instantiate(HitParticle, transform.position, transform.rotation);


        }
        if (other.gameObject.tag == "BigEnemy")
        {
            Debug.Log("Code ACTIVATED");
            Debug.Log("WeaponNum = " + sworddamage);
            //Debug.Log("Sword Damage IST: " sworddamage);
            rh = other.gameObject.GetComponent<ratOgreHealth>();
            rh.AddjustCurrentHealth(sworddamage);
            

        }





    }






}
