using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private Animator playerAnim;
    [HideInInspector]
    public bool isAttacking = false;

    private bool canAttack;
    private bool canAttack2;
    private bool canAttack3;
    private float bufferTimer = 1.0f;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        canAttack = true;
        canAttack2 = false;
        canAttack3 = false;

    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0) && canAttack == true)
        {
            canAttack = false;
            playerAnim.SetTrigger("attack");
            StartCoroutine(AttackBuffer(bufferTimer));
        }

        if(Input.GetMouseButtonDown(0) && canAttack2 == true)
        {
            canAttack = false;
            canAttack2 = false;
            playerAnim.SetTrigger("attack2");
            StartCoroutine(AttackBuffer(bufferTimer));
        }

        if(Input.GetMouseButtonDown(0) && canAttack3 == true)
        {
            canAttack = false;
            canAttack3 = false;
            playerAnim.SetTrigger("attack3");
            playerAnim.ResetTrigger("attack");
            StartCoroutine(AttackBuffer(bufferTimer));
        }
    }

    private IEnumerator AttackBuffer(float bufferTimer)
    {
        yield return new WaitForSeconds(bufferTimer);
        canAttack = true;
    }

    public void EnableAttack2()
    {
        canAttack2 = true;
    }
    public void DisableAttack2()
    {
        canAttack2 = false;
        playerAnim.ResetTrigger("attack2");
    }
    public void EnableAttack3()
    {
        canAttack3 = true;
    }
    public void DisableAttack3()
    {
        canAttack3 = false;
        playerAnim.ResetTrigger("attack3");
    }
    public void IsAttacking()
    {
        isAttacking = true;
    }
    public void IsNotAttacking()
    {
        isAttacking = false;
    }
}
