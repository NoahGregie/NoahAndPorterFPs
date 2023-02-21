using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponController : MonoBehaviour
{

    public GameObject Sword;
    public bool CanAttack = true;
    public float AttackCooldown = 1f;
    public bool isAttacking = false;
    public TMP_Text text;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {



            if (CanAttack)
            {

                SwordAttack();

            }

        }
    }


    public void SwordAttack()
    {
        isAttacking = true;
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());


    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }


}
