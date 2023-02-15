using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gernadelunchger : MonoBehaviour
{
    // Start is called before the first frame update
    public float throwForce = 40f;
    public GameObject gernade;

    bool canShoot;
  public  int currentammo;



    public TMP_Text text;

    public void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot && currentammo >0)
        {
            canShoot = false;
            currentammo--;
            ThrowGernade();
            text.SetText("Gernades " + currentammo);
        }




    }

    void ThrowGernade()
    {


     GameObject GEernade=   Instantiate(gernade, transform.position, transform.rotation);
        Rigidbody rb = GEernade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce);
        canShoot = true;
    }



}
