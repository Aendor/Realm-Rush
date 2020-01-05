using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDerease = 1;
    [SerializeField] Text healthText;

    void Start()
    {
        healthText.text = health.ToString();
    }
    
    private void OnTriggerEnter()
    {
        health -= healthDerease;
        healthText.text = health.ToString();

        if (health <= 0)
        {
            healthText.text = "DED";
        }
    }
}
