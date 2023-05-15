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

    public GameObject key;
    public int x;//45
    public int y;//2
    public int z;//98

    public int x1;//38
    public int y2;//2
    public int z1;//98
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

       
        Instantiate(equation, new Vector3(x, y, z), Quaternion.identity);
        key.transform.position = new Vector3(x1, y2,z1);
        GameMaster.formulas++;
        hasRun = true;
    }

   
}
