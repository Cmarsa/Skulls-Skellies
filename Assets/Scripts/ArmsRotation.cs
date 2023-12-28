using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsRotation : MonoBehaviour
{
    public PlayerController playerController;

    public float rotationSmoothness = 5f; // Adjust the smoothness factor as needed

    // Start is called before the first frame update
    void Start()
    {
        if (playerController == null)
        {
            Debug.LogError("PlayerController reference not set. Attach the PlayerController script to the player and assign it to the ArmsRotation script.");
        }
    }

    // Update is called once per frame
    void Update() 
    {
        if (playerController != null)
        {
            // Apply the player's rotation to this GameObject smoothly
            Quaternion targetRotation = Quaternion.Euler(playerController.xRotation, playerController.yRotation, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmoothness);
        }
    }
}
