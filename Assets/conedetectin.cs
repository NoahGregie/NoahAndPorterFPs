using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conedetectin : MonoBehaviour
{
  public  Rigidbody rb;
    public bool active = false;


   




   private void Start()
    {
        rb = rb.GetComponent<Rigidbody>();
      
       
    }

    // Update is called once per frame


    //  private void OnCollisionEnter(Collision collision)
    //  {
    //      if (collision.collider.name == "Player")
    //   {
    //        Debug.Log(collision.collider.name);

    //  }
    // }





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
