using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ratOgreHealth : MonoBehaviour
{

    public float currentHealth = 10f;
    public float maxHealth = 10f;

    public bool isDead;
    public Animator animator;
    public int xPos;
    public int yPos;
    public int zPos;
    Rigidbody rb;
    public GameObject Blood;



    void Start()
    {

        //get animator attacted to game object
        animator = gameObject.GetComponent<Animator>();
    
      

    }
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
         

            animator.SetBool("PlaySpecialRun", false);
            animator.SetBool("playSepcialDeath", true);
            //   Instantiate(Blood, new Vector3(xPos, 1, zPos), Quaternion.identity);

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
            StartCoroutine(ExecuteAfterTime(1));


        }
        IEnumerator ExecuteAfterTime(float time)
        {
            yield return new WaitForSeconds(time);

            Destroy(gameObject);

        }

    }
}

