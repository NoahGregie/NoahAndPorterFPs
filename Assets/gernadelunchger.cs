using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gernadelunchger : MonoBehaviour
{
    // Start is called before the first frame update
    public float throwForce = 40f;
    public GameObject gernade;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            ThrowGernade();

        }




    }

    void ThrowGernade()
    {


     GameObject GEernade=   Instantiate(gernade, transform.position, transform.rotation);
        Rigidbody rb = GEernade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce);
    }



}
