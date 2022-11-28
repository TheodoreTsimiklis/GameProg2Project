using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    private int health = 50;
    public GameObject skeleton;
    public Slider healthBar;
    public Animator animator;
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
            animator.SetTrigger("die");
            //disable the enemy movement
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;

            //destroy object after 2 seconds to allow animation to play
            Destroy(skeleton, 2f);
            
        }
        else
        {
            //TODO: play enemy get hit animation


        }
    }
}
