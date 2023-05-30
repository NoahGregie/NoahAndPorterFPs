using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnernakai : MonoBehaviour
{
    public GameObject theEnemy;

    public int enemyCount;
    public GameObject finalBoss;
    public int secondEnemyCount;
    public int MaxEnemyCount;
    Vector3 bar;
    void Start()
    {
        StartCoroutine(EnemyDrop());
        bar = transform.position;
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < MaxEnemyCount)
        {
            // xPos = Random.Range();
            //  zPos = Random.Range();
            Instantiate(theEnemy, bar, Quaternion.identity, transform);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
       
    }
}