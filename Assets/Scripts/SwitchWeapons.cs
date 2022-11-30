using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform[] weapons;

    [Header("Keys")]
    [SerializeField] private KeyCode[] keys;

    [Header("Settings")]
    [SerializeField] private float switchTime;


    private int selectedWeapon;
    private float timeSinceLastSwitch;
     public WeaponController wc;
    private void Start()
    {
        SetWeapons();
        Select(selectedWeapon);

        timeSinceLastSwitch = 0f;
    }

    private void SetWeapons()
    {
        weapons = new Transform[transform.childCount];

        //puts weapons into a array
        for (int i =0; i < transform.childCount; i++)
        {
            weapons[i] = transform.GetChild(i);

        }

        if (keys == null) keys = new KeyCode[weapons.Length];
    }

    private void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        for(int i =0; i<keys.Length; i++)
        {
            if (Input.GetKeyDown(keys[i]) && timeSinceLastSwitch >= switchTime) 
            selectedWeapon = i;
        }

        if (previousSelectedWeapon != selectedWeapon) Select(selectedWeapon);
        wc.CanAttack = true;
        timeSinceLastSwitch += Time.deltaTime;

    }



    private void Select(int weaponIndex)
    {

     for(int i =0; i< weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(i == weaponIndex);
        }
        timeSinceLastSwitch = 0f;

        OnweaponsSelected();



    }


    private void OnweaponsSelected()
    {
        print("newWeapons");

    }




}
