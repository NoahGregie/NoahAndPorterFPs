using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerndae : MonoBehaviour
{


    public float delay = 3f;


    public float radius = 5f;
    public GameObject explosioneffect;
    float countdown;
    public float force = 700f;
    bool hasExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if(countdown <= 0f && !hasExploded )
        {

            Explosion();
            hasExploded = true;


        }

    }

    void Explosion()
    {

        //get all nearby objects and then add force to objects

        Instantiate(explosioneffect, transform.position, transform.rotation);

       Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

      foreach (Collider nearbyObject in colliders)
        {

            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            EnemyHealth eh = nearbyObject.GetComponent<EnemyHealth>();
            ratOgreHealth rh = nearbyObject.GetComponent<ratOgreHealth>();
          
            if(rb!= null &&eh!= null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
                eh.AddjustCurrentHealth(-1);

            }

            if(rb!= null &&rh!= null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
                rh.AddjustCurrentHealth(-250);
            }


        }



        Destroy(gameObject);
        
    }
}
