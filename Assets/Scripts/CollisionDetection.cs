using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wp;
    public GameObject HitParticle;
    public EnemyHealth eh;

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Enemy"&& wp.isAttacking)
        {

            
            eh.AddjustCurrentHealth(-1);

        }


    }

}
