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
    public int MaxEnemyCount;

     void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount <30 )
        {
            xPos = Random.Range(-22, 10);
            zPos = Random.Range(7, 4);
            Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
        if (enemyCount == 300)
        {

            Instantiate(finalBoss, new Vector3(-22, 1, 170), Quaternion.identity);

        }
    }

}
