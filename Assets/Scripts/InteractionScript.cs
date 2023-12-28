using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public Animator chestAnim;
    public GameObject chestText;
    private RaycastHit hit;
    private Transform main;

    void Start()
    {
        chestText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        main = Camera.main.transform;

        if(Physics.Raycast(transform.position, main.forward, out hit, 5.0f))
        {
            if(hit.collider.CompareTag("Chest"))
            {
                chestText.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    chestText.SetActive(false);
                    chestAnim.SetBool("isOpen", true);
                }
            }
        }
        else
        {
            chestText.SetActive(false);
        }
    }
}
