
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [Header("Gun Settings")]
    public float fireRate = 0.1f;
    public int clipSize = 30;
    public int reservedAmmoCapticity = 270;

    //varaibeles that change throughout code
    bool canShoot;
    int currentAmmonInClip;
    int ammoInReserve;



    //muzzleFlash
    public Image muzzleFlashImage;
    public Sprite[] flashes;


    //Aiming
    public Vector3 normalLocalPosition;
    public Vector3 aimingLocaalPosition;

    public float aimSmoothing = 10;

    [Header("Mouse Settings")]
    public float mouseSensitivity = 1;
    Vector2 currentRotation;
    public float weaponsSwayAmount = 10;

    //weapon recoil
    public bool randomizeRecoil;
    public Vector2 randomRecoilConstraints;
    //you only need to assign this if randmoize recoil is off.
    public Vector2 recoilPattern;

    

    private void Start()
    {
        currentAmmonInClip = clipSize;
        ammoInReserve = reservedAmmoCapticity;
        canShoot = true;
    }

    private void Update()
    {
       
        DetermineAim();

        //if this is on, you cant shoot for somereason
       //DetermineRotation();


       if(Input.GetMouseButton(0) && canShoot && currentAmmonInClip > 0)
        {
            canShoot = false;
            currentAmmonInClip--;
            StartCoroutine(ShootGun());
            

        }
       else if(Input.GetKeyDown(KeyCode.R)&& currentAmmonInClip <clipSize && ammoInReserve>0)
        {
            int amountNeeded = clipSize - currentAmmonInClip;
            if(amountNeeded >= ammoInReserve)
            {
                currentAmmonInClip += ammoInReserve;
                ammoInReserve -= amountNeeded;

            }
            else
            {
                currentAmmonInClip = clipSize;
                ammoInReserve -= amountNeeded;
            }
        }
    }
    void DetermineRotation()
    {
        Vector2 mouseAxis = new Vector2(Input.GetAxisRaw("Mouse x"), Input.GetAxisRaw("Mouse y"));

        mouseAxis *= mouseSensitivity;
        currentRotation += mouseAxis;

        currentRotation.y = Mathf.Clamp(currentRotation.y, -90, 90);

        transform.localPosition += (Vector3)mouseAxis * weaponsSwayAmount / 1000;

        transform.root.localRotation = Quaternion.AngleAxis(currentRotation.x, Vector3.up);
        transform.parent.localRotation = Quaternion.AngleAxis(-currentRotation.y, Vector3.right);
    }
    void DetermineAim()
    {
        Vector3 target = normalLocalPosition;
        if (Input.GetMouseButton(1)) target = aimingLocaalPosition;

        Vector3 desiredPostition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * aimSmoothing);

        transform.localPosition = desiredPostition;

    }
    
    void DetermineRecoil()
    {
        transform.localPosition -= Vector3.forward * 0.1f;

        if(randomizeRecoil)
        {
            float xRecoil = Random.Range(-randomRecoilConstraints.x, randomRecoilConstraints.x);
            float yRecoil = Random.Range(-randomRecoilConstraints.y, randomRecoilConstraints.y);

            Vector2 recoil = new Vector2(xRecoil, yRecoil);

            currentRotation += recoil;
        }
    }
    IEnumerator ShootGun()
    {
        DetermineRecoil();
        StartCoroutine(MuzzleFlash());

        RayCastForEnemy();
      
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    IEnumerator MuzzleFlash()
    {
        muzzleFlashImage.sprite = flashes[Random.Range(0, flashes.Length)];
        muzzleFlashImage.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        muzzleFlashImage.sprite = null;
        muzzleFlashImage.color = new Color(0,0,0,0);
    }

    void RayCastForEnemy()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.parent.position, transform.parent.forward, out hit, 1 << LayerMask.NameToLayer("Enemy")))
                {
            try {
                Debug.Log("Hit A Enemy");
                Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.None;
                rb.AddForce(transform.parent.transform.forward * 500);
            
            }
            catch { }

        }
                

    }
}
