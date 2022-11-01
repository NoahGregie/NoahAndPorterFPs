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

        speed = Random.Range(2, 6);
        //makes enemy moves tword charcter
      //  if (pm.crouch == true)
       // {
       //     transform.LookAt(target);
       // }
      //  else
      //  {
            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);

            rig.MovePosition(pos);
            transform.LookAt(target);
        //}
       
    }
  
}
