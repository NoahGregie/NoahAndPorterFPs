using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScriptez : MonoBehaviour
{
    public string level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");


        if (gameObjects.Length == 0 )
        {

            endlovel();
        }
    }


    private void endlovel()
    {

        SceneManager.LoadScene(level);


    }

}
