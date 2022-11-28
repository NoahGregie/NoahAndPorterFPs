using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomingScript : MonoBehaviour
{

    public Transform target;
    public float speed;
    Rigidbody rig;
    movemen pm;
    
   
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        pm = GetComponent<movemen>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //good script but rats can fly
         Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        pos.y = 1f;

        transform.LookAt(target);

        



        rig.MovePosition(pos);

    }
       
    }
  

