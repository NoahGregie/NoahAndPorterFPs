using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedGridSpawner : MonoBehaviour
{

    public GameObject prefab;
    public int numberOfObjects = 20;
    public float radius = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
        for( int i =0; i <numberOfObjects; i++)
        {

            float angle = i * Mathf.PI * 2 / numberOfObjects;


            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            Instantiate(prefab, pos, Quaternion.identity);





        }





    }

    // Update is called once per frame
    void Update()
    {
        
    }
}