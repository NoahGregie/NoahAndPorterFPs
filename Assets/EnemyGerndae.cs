using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGerndae : MonoBehaviour
{


    public float delay = 3f;


    public float radius = 5f;
    public GameObject explosioneffect;
    float countdown;
    public float force = 700f;
    bool hasExploded = false;
    public float gernadeDamage;

   public  bool dealdamage = false;

    PlayerHealth ph;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f && !hasExploded)
        {

           Explosion();
           
            hasExploded = true;


        }

    }

     public void Explosion()
    {

        //get all nearby objects and then add force to objects

        Instantiate(explosioneffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
          //  Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
           
            ph = player.GetComponent<PlayerHealth>();
            if (nearbyObject.gameObject.CompareTag("Player") )
            {
                // rb.AddExplosionForce(force, transform.position, radius);
                ph.TakeDamage(gernadeDamage);
                dealdamage = true;
                Debug.Log("Genade");
            }


        }



        Destroy(gameObject);

    }




    
}
