using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds : MonoBehaviour
{
    public int x;
    public int y;
    public int z;

   
    // Update is called once per frame
    void Update()
    {
     
        transform.position += new Vector3(x,y, z);
    }
}
