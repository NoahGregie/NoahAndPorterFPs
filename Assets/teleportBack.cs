using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleportBack : MonoBehaviour
{
    GameMaster gm;
    public GameObject game;
    public bool isOn = false;
    public string levelUnload;
    // Start is called before the first frame update


    // Update is called once per frame

    public void Update()
    {

        if (isOn == true)
        {

            SceneManager.UnloadSceneAsync(levelUnload);

        }


    }

    public void OnMouseDown()
    {

        // this object was clicked - do something


        //add in new scene



        LoadSceneOnTop();

        isOn = true;




        //Destroy(gameObject);

    }

    public static void LoadSceneOnTop()
    {
        //reactivate level 2
        GameMaster.active = true;



    }
 
}
