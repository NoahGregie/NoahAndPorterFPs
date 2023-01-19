using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int yPos;
    public int enemyCount;
    public GameObject finalBoss;
    public int secondEnemyCount;
    public int MaxEnemyCount;
    
     void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount <MaxEnemyCount )
        {
           // xPos = Random.Range();
          //  zPos = Random.Range();
            Instantiate(theEnemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
        if (enemyCount == MaxEnemyCount)
        {

            Instantiate(finalBoss, new Vector3(xPos, yPos, zPos), Quaternion.identity);

        }
    }

}
