using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerndae : MonoBehaviour
{


    public float delay = 3f;


    public float radius = 5f;
    public GameObject explosioneffect;
    float countdown;

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

        Instantiate(explosioneffect, transform.position, transform.rotation);

       Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

      //foreach (Collider nearbyObject)



        Destroy(gameObject);

    }
}