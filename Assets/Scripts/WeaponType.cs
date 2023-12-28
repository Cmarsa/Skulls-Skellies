using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponType : MonoBehaviour
{
    public enum weaponType
    {
        knife,
        sword,
        axe,
        hammer
    }

    public GameObject[] weapons;
    public GameObject weaponWielder;
    public weaponType chosenWeapon;

    [HideInInspector]
    public int chosenWeaponID;
    
    private Animator weaponAnimator;
    public AttackScript attackScript;

    // Start is called before the first frame update
    void Start()
    {
        chosenWeaponID = (int)chosenWeapon;
        weaponAnimator = weaponWielder.GetComponent<Animator>();
        attackScript = GetComponentInParent<AttackScript>();
    }

    // Update is called once per frame
    void Update()
    {
        ChooseWeapon();

        for(int i = 0; i < weapons.Length; i++)
        {
            if(i == chosenWeaponID)
            {
                StartCoroutine(TakeOutWeapon(i));
            }
            else
            {
                StartCoroutine(PutAwayWeapon(i));
            }
        }

        if(chosenWeaponID == 2 || chosenWeaponID == 3)
        {
            weaponAnimator.SetBool("isTwoHanded", true);
            weaponAnimator.SetBool("isOneHanded", false);
        }
        else
        {
            weaponAnimator.SetBool("isOneHanded", true);
            weaponAnimator.SetBool("isTwoHanded", false);
        }
    }

    private void ChooseWeapon()
    {
        if(attackScript.isAttacking == false)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1) && chosenWeaponID != 0)
            {
                chosenWeaponID = 0;
                weaponAnimator.SetTrigger("takeOutWeapon1");
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2) && chosenWeaponID != 1)
            {
                chosenWeaponID = 1;
                weaponAnimator.SetTrigger("takeOutWeapon1");
            }
            else if(Input.GetKeyDown(KeyCode.Alpha3) && chosenWeaponID != 2)
            {
                chosenWeaponID = 2;
                weaponAnimator.SetTrigger("takeOutWeapon2");
            }
            else if(Input.GetKeyDown(KeyCode.Alpha4) && chosenWeaponID != 3)
            {
                chosenWeaponID = 3;
                weaponAnimator.SetTrigger("takeOutWeapon2");
            }
        }
    }

    IEnumerator TakeOutWeapon(int weaponID)
    {
        yield return new WaitForSeconds(0.4f);
        weapons[weaponID].SetActive(true);    
    }
    IEnumerator PutAwayWeapon(int weaponID)
    {
        yield return new WaitForSeconds(0.4f);
        weapons[weaponID].SetActive(false);   
    }
}
