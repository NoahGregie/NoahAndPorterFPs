using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingScriptAddon : MonoBehaviour
{


    private Rigidbody rb;

    public int damage;
    private bool targethit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (targethit)
            return;
        else
            targethit = true;

        //stick
        rb.isKinematic = true;

        //projectile moves with target
        transform.SetParent(collision.transform);





        if (collision.gameObject.GetComponent<EnemyDamage>() != null)
        {

            EnemyDamage enemy = collision.gameObject.GetComponent<EnemyDamage>();

            enemy.TakeDamage(damage);

            Destroy(gameObject);

        }
    }
}
