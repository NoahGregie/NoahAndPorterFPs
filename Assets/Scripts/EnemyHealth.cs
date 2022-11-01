using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float currentHealth = 10f;
    public float maxHealth = 10f;
   
    public bool isDead;

    void Update()
    {
        AddjustCurrentHealth(0);
    }

    public void AddjustCurrentHealth(float adj)
    {
        currentHealth += adj;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (maxHealth < 1)
        {
            maxHealth = 1;
        }
        if (isDead == true)
        {
            Destroy(gameObject);

        }
        
    }
}
