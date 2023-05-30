using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthScrpitforNakaipillars : MonoBehaviour
{

    public int nakaiPillars = 3;
    public TMP_Text nakai;

    // Start is called before the first frame update
  
    public void OnMouseDown()
    {
        
        nakaiPillars--;
        nakai.SetText(nakaiPillars + "Left");
        //  nakai.SetText(nakaiPillars + "Left");
        Destroy(gameObject);

    }



}
