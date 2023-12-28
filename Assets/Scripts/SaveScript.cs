using System.Collections;
using System.Collections.Generic;
using MagicPigGames;
using Unity.VisualScripting;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public float health = 100;

    public GameObject healthBar;
    public bool takeDamage;
    public bool heal;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.GetComponent<ProgressBar>().SetProgress(health * 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        if(takeDamage == true)
        {
            takeDamage = false;
            TakeDamage();
        }

        if(heal == true)
        {
            heal = false;
            Heal();
        }
    }

    public void TakeDamage()
    {
        health -= 10;
        healthBar.GetComponent<ProgressBar>().SetProgress(health * 0.01f);
    }

    public void Heal()
    {
        health += 10;
        healthBar.GetComponent<ProgressBar>().SetProgress(health * 0.01f);
    }
}
