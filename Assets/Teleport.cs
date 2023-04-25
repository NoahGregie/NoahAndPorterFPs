using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

    public bool isOn = false;
    // Start is called before the first frame update


    // Update is called once per frame
    public string level;
   

    public void OnMouseDown()
    {

        // this object was clicked - do something


        //add in new scene

       

       

        isOn = true;
        SceneManager.LoadScene(level, LoadSceneMode.Additive);

        

        Destroy(gameObject);

    }

  
    
  
}
