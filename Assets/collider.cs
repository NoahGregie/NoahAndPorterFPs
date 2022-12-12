using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{

    public EnemyHomingScript eh;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            eh.cansee = true;


        }
    }
}
