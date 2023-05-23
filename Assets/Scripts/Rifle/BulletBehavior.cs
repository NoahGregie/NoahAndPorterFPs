using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{


    public float piercing = 100;



    private void OnTriggerEnter(Collider other)
    {
        print("hit" + other.name + "!");

        //GetComponent<other>
        //EnemyHealth EnemyHealth = other.collider.GetComponent<EnemyHealth>();
        //EnemyHealth.AddjustCurrentHealth(-1);

        //other.transform.tag == "Enemy"
        if (other.GetComponent<Collider>().gameObject.tag != "BigEnemy")
        {
            Debug.Log("SKALITZ");
            // do damage here, for example:
            other.gameObject.GetComponent<EnemyHealth>().AddjustCurrentHealth(-1);
            piercing = piercing - 1;

            //EnemyHealth EnemyHealth = hit.collider.GetComponent<EnemyHealth>();
            //EnemyHealth.AddjustCurrentHealth(-1);

        }



        //if (piercing == 0) 
        //{ 
        //    Destroy(gameObject); 
        //}
        //Destroy(gameObject);
    }

}