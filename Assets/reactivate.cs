using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reactivate : MonoBehaviour
{

    public void Update()
    {
        if(GameMaster.active== true)
        {

            reaactivate();

        }
    }

    public void reaactivate()
    {
        Debug.Log("111111111111");
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        GameMaster.active = false;
    }

  
}
