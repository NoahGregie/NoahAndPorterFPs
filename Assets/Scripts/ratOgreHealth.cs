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
        Debug.Log("RAT OGRE FEELS NO PAIN!!!!!!!!!");
        currentHealth += adj;
        Debug.Log(currentHealth);
        Debug.Log(adj);
        if (currentHealth <= 0) 
        {
            currentHealth = 0;
            isDead = true;
            //Debug.Log("Attack of the Dead RatOGRE");

            

            animator.SetBool("PlaySpecialRun", false);
            animator.SetBool("PlaySpecialDeath", true);

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
            StartCoroutine(ExecuteAfterTime(2));

        }
        IEnumerator ExecuteAfterTime(float time)
        {

            SpecialRathomingScript specialRathomingScript = GetComponent<SpecialRathomingScript>();
            specialRathomingScript.isDead();

            yield return new WaitForSeconds(time);

            Destroy(gameObject);

        }

    }
}

