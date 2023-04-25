using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{


    public static bool active = false;

    public static int formulas = 0;
    void Awake()
    {
        DontDestroyOnLoad(this);
    }




   
    //when ative then reactiveate parent 
    //reactivate when loading in new scence


}
