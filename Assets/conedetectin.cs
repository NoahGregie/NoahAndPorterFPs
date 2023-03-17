using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conedetectin : MonoBehaviour
{
  public  Rigidbody rb;
    public bool active = false;




    public LayerMask worldLayer;


    private void Start()
    {
        rb = rb.GetComponent<Rigidbody>();
      
       
    }

    public void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.parent.forward, out hit, 100.0f, worldLayer))
        {
            active = true;
            Debug.Log(active);
        }
           
     


        else
        {

            active = false;
            Debug.Log(active);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           // Debug.Log("An object enter.");
            //Freeze all positions
           // rb.constraints = RigidbodyConstraints.FreezePosition;
            active = true;
             }



    }


   public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           // Debug.Log("An object left.");

            active = false;
        }



    }


}
