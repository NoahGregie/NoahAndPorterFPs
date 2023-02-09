using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private float health;
    private float lerpTimer;
    [Header("Health Bar")]
    public float maxHealth = 100;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;
    [Header("Damage Overlay")]
    public Image overlay;
    public float duration;
    public float fadeSpeed;


    public bool timer = true;
    


    private float durationTimer;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        if (overlay.color.a > 0)
        {
            if (health < 30)
               // StartCoroutine(HealHealth());
            return;
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                //fade thge image
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }

        timer = false;
    }

    IEnumerator HealHealth()
    {
      
        
        yield return new WaitForSecondsRealtime(3.0f);
        ResoreHealth(30);
    }
    

    public void UpdateHealthUI()
    {

        //Debug.Log(health);
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float precentComplete = lerpTimer / chipSpeed;
            precentComplete = precentComplete * precentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, precentComplete);
        }
        if (fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float precentComplete = lerpTimer / chipSpeed;
            precentComplete = precentComplete * precentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, precentComplete);

        }
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("Warcrimes");
        health -= damage;
        lerpTimer = 0f;
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
       
    }
    public void ResoreHealth(float healAmount)
    {

        health += healAmount;
        lerpTimer = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);

           
            StartCoroutine(ExecuteAfterTime(5));
        }

        //turn the timer false, and then sets a timer for healing. If timer becomes false again reset timer. 
        if (collision.collider.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(10);
            StartCoroutine(ExecuteAfterTime(5));
        }



    }

    IEnumerator ExecuteAfterTime(float time)
    {
       while( timer == true); 
     //   ResoreHealth(10);
        yield return new WaitForSeconds(time);

        // while (timer == true) ;

        // yield return new WaitForSeconds(time);
    }

   

}
