using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    private int health = 50;
    public GameObject skeleton;
    public Slider healthBar;
    // Start is called before the first frame update
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
        if (health <= 0)
        {
            //TODO: set enemy death animation

            skeleton.SetActive(false);
        }
        else
        {
            //TODO: play enemy get hit animation


        }
    }
}
