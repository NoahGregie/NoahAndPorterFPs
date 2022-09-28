
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


    private void Start()
    {
        currentAmmonInClip = clipSize;
        ammoInReserve = reservedAmmoCapticity;
        canShoot = true;
    }

    private void Update()
    {
        DetermineAim();


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
    void DetermineAim()
    {
        Vector3 target = normalLocalPosition;
        if (Input.GetMouseButton(1)) target = aimingLocaalPosition;

        Vector3 desiredPostition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * aimSmoothing);

        transform.localPosition = desiredPostition;

    }
    IEnumerator ShootGun()
    {
        StartCoroutine(MuzzleFlash());
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
}
