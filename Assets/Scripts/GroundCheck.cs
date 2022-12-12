using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{



    [Header("Ground Check")]
    public float enemyHeight;
    public LayerMask whatIsGround;
    public bool grounded;






    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, enemyHeight * 0.5f + 0.3f, whatIsGround);
    }
}
