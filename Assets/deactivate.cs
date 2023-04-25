using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivate : MonoBehaviour
{
    // Start is called before the first frame update


    Teleport tp;
    public GameObject t;

    public void Update()
    {
        

        tp = t.GetComponent<Teleport>();
 
        if (tp.isOn == true)
        {

            die();
            
        }


    }



    public void die()
    {
        


        
        gameObject.SetActive(false);
        tp.isOn = false;

    }





}
