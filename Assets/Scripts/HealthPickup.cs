using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public GameObject player;
    public GameObject healText;
    private SaveScript saveScript;
    // Start is called before the first frame update
    void Start()
    {
        saveScript = player.GetComponent<SaveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * 120 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && saveScript.health < 100)
        {
            saveScript.heal = true;
            healText.SetActive(true);
            Destroy(gameObject);
        }
    }
}
