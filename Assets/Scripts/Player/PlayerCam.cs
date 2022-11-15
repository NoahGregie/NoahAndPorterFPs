using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    public float sensX;
    public float sensY;

    public Transform oreintation;

  float xRotation;
   
    float yRotation;
   

    GunController gc;
   public Vector2 currentRotation2;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
       

    }

    private void Update()
    {
        //get mouse inpurt
       float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;
       float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensY;




        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

      //  rotate cam and oreintation
      transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        oreintation.rotation = Quaternion.Euler(0, yRotation, 0);


        Vector2 mouseAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        
        currentRotation2 += mouseAxis;
        
    }
    public void recoil()
    {


        xRotation += currentRotation2.x;
        yRotation += currentRotation2.y;

    }




}
