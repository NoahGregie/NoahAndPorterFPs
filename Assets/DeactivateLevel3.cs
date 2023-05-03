using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateLevel3 : MonoBehaviour
{






    Teleport tb;
    public GameObject b;

    public void Update()
    {

        tb = b.GetComponent<Teleport>();



        if (tb.isOn == true)
        {

            die2();
        }


    }





    public void die2()
    {


        gameObject.SetActive(false);
        tb.isOn = false;

    }



}
