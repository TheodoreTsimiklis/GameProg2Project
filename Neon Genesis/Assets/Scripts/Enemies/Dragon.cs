using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dragon : MonoBehaviour
{
    private int health = 100;
    public GameObject dragon;
    public Slider healthBar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;

        
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            //TODO: set enemy death animation

            dragon.SetActive(false);
        }
        else
        {
            //TODO: play enemy get hit animation


        }
    }
}
