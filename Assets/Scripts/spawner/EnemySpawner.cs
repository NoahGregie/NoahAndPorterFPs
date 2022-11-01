using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    public GameObject finalBoss;
    public int secondEnemyCount;


     void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 10)
        {
            xPos = Random.Range(-43, 2);
            zPos = Random.Range(171, 200);
            Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.00000000001f);
            enemyCount += 1;
        }
        if (enemyCount == 10)
        {

            Instantiate(finalBoss, new Vector3(-22, 1, 170), Quaternion.identity);

        }
    }

}
