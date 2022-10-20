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


    private float durationTimer;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b,0);
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        if(overlay.color.a > 0)
        {
            if (health < 30)
                return;
            durationTimer += Time.deltaTime;
            if(durationTimer > duration)
            {
                //fade thge image
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
        
    }
    public void UpdateHealthUI()
    {

        //Debug.Log(health);
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if(fillB > hFraction)
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
}
