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
    private void Update()
    {
        nakai.SetText(nakaiPillars + "Left");
    }
    public void OnMouseDown()
    {

        nakaiPillars=nakaiPillars - 1;
      //  nakai.SetText(nakaiPillars + "Left");
      

    }



}
