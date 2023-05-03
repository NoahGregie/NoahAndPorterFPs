using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    public bool ok = false;
     GameObject[] enemies;
    private bool hasRun = false;
    public GameObject equation;
    public void Update()
    {


        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");


        if(gameObjects.Length == 0 && hasRun==false)
        {
            endLevel();
          

        }

     

    }


    public void endLevel()
    {

        Debug.Log("YOU WIN");
        Instantiate(equation, new Vector3(45, 2, 98), Quaternion.identity);
        GameMaster.formulas++;
        hasRun = true;
    }

   
}
