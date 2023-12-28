using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private Animator animator;
    private new BoxCollider collider;
    private bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
        isOpen = animator.GetBool("isOpen");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = animator.GetBool("isOpen");
        if(isOpen)
        {
            collider.enabled = false;
        }
    }
}
