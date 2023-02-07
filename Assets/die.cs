using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destry", 3);
    }

    // Update is called once per frame
   void destry()
    {

        Destroy(gameObject);

    }
}
