using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour
{

    [SerializeField] GameObject flashLightlight;
    private bool flashlightactive = false;


    // Start is called before the first frame update
    void Start()
    {
        flashLightlight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F");
            if(flashlightactive == false)
            {

                flashLightlight.gameObject.SetActive(true);
                flashlightactive = true;

            }

            else
            {

                flashLightlight.gameObject.SetActive(false);
                flashlightactive = false;

            }

        }
    }
}
