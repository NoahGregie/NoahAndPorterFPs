using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    public bool ok = false;
    public GameObject[] enemies;
    public void Start()
    {
        spwanRandom();
        
    }

    public void Update()
    {


        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");


        if(gameObjects.Length == 0)
        {
            endLevel();
          

        }

     

    }


    public void endLevel()
    {


      
        SceneManager.LoadScene(sceneBuildIndex:1);
    }

    public void spwanRandom()
    {

        Instantiate(enemies[Random.Range(0, enemies.Length - 1)]);


    }
}
