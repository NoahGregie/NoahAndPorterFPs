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
}
