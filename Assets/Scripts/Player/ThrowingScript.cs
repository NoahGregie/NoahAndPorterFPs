using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingScript : MonoBehaviour
{
    [Header("Refrences")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;


    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwkey = KeyCode.G;
    public float throwForce;
    public float throwUpwardForce;

    bool readyTothrow;

    


    private void Start()
    {

        readyTothrow = true;



    }
    private void Update()
    {
        
        if(Input.GetKeyDown(throwkey)&& readyTothrow && totalThrows > 0)
        {

            Throw();
        }
    }

   

    private void Throw()
    {
        readyTothrow = false;

        //make object
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);
        //get rigid body
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        //calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 10000f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;

        }

        //ad forec             throws where cam is facing   
        Vector3 forceToAdd =cam.transform.forward* throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        //throw cooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }
    private void ResetThrow()
    {
        readyTothrow = true;


    }

}
