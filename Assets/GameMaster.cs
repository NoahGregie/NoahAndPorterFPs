using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMaster : MonoBehaviour
{

    public TMP_Text text;
    public static bool active = false;
    public static bool differentScenes = false;

    public static int formulas = 0;
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Update()
    {
        text.SetText(formulas + "/" + 3);
        text.color = Color.magenta;
    }



    //when ative then reactiveate parent 
    //reactivate when loading in new scence


}
