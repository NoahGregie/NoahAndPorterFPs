using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarFiller : MonoBehaviour
{

    movemen pm;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        FillCode.SetHealthBarValue(1);
       
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCrouch();



    }


    public void ChangeCrouch()
    {
        pm = player.GetComponent<movemen>();
        if (pm.crouch == true)
        {

            FillCode.SetHealthBarValue(FillCode.GetHealthBarValue() - 0.001f);
            Debug.Log("Bar");
        }


        else
        {
            // FillCode.SetHealthBarValue(FillCode.GetHealthBarValue() + 0.0001f);
        }


    }

    public void stopCrouch()
    {

       
      


    }
    
}
