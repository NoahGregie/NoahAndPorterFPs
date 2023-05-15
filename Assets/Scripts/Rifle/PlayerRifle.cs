using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRifle : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 6;
    public float lifetime = 3;
    public float AttackCooldown = 0.5f;
    public bool CanAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        if(Input.GetMouseButton(0))
        //if(1 == 1)
        {
            if (CanAttack)
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab);

        //Physics.IgnoreCollision(bullet.GetComponent<Collider>(), bulletSpawn.parent.GetComponent<Collider>());

        bullet.transform.position = bulletSpawn.position;

        Vector3 rotation = bullet.transform.rotation.eulerAngles;

        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

        CanAttack = false;

        StartCoroutine(DestroyBulletAfterTime(bullet, lifetime));
        StartCoroutine(ResetFireCooldown());
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);

    }

    IEnumerator ResetFireCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

}
