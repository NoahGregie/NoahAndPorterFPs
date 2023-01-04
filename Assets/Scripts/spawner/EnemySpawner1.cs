using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner1 : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int yPos;
    public int enemyCount;
    public GameObject finalBoss;
    public int secondEnemyCount;
    public int MaxEnemyCount;
    public float TimeSpace;

     void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount <10 )
        {
          //  xPos = Random.Range(-22, 10);
          //  zPos = Random.Range(7, 4);
          //  yPos = Random.Range(22, 4);
            Instantiate(theEnemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(TimeSpace);
            enemyCount += 1;
        }
        if (enemyCount == 300)
        {

            Instantiate(finalBoss, new Vector3(-22, 1, 170), Quaternion.identity);

        }
    }

}
