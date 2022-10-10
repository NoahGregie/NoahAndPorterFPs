using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomingScript : MonoBehaviour
{

    public Transform target;
    public float speed = 5f;
    Rigidbody rig;
   
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {




        //makes enemy moves tword charcter
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);

        rig.MovePosition(pos);
        transform.LookAt(target);

       
    }
}
