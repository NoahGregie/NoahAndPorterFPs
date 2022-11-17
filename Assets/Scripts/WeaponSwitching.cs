using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{

    public int SelectedWeapon = 0;



    private void Start()
    {

        selectWeapon();

    }

    void Update()
    {
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(SelectedWeapon >= transform.childCount - 1)
            
                SelectedWeapon = 0;
           else     
                SelectedWeapon++;

            }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
           if(SelectedWeapon <= 0)

                SelectedWeapon = transform.childCount -1;
            else
                SelectedWeapon--;

        }

    }


    


    void selectWeapon()
    {
        int i = 0;
        foreach  (Transform weapon in transform)
        {

            if (i == SelectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;

        }


    }
}
