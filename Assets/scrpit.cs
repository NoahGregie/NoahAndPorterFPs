using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrpit : MonoBehaviour
{
    public float distance;

    RaycastHit hit;
    
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * distance, Color.green);
        raycast();
    }


    //ray cast works but is too tall
    public void raycast()
    {
        Ray ray = new Ray(transform.position, transform.forward);
  
        if(Physics.Raycast(ray, out hit, distance))
        {

            if (hit.collider.gameObject.CompareTag("Player"))
            {

                Debug.Log("dfasdfasdfasdf");

            }


        }

    }




}






