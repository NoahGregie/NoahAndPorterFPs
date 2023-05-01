using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivate : MonoBehaviour
{
    // Start is called before the first frame update


    Teleport tp;
    public GameObject t;


   // Teleport tb;
    //public GameObject b;

    public void Update()
    {

      //  tb = b.GetComponent<Teleport>();
        tp = t.GetComponent<Teleport>();
 
        if (tp.isOn == true)
        {

            die();
            
        }
       // if(tb.isOn == true)
      //  {

      //      die2();
      //  }


    }



    public void die()
    {
        


        
        gameObject.SetActive(false);
        tp.isOn = false;

    }

   // public void die2()
   // {


    //    gameObject.SetActive(false);
    //    tp.isOn = false;

  //  }



}
