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
    private bool alreadyAttacked;
    //skeleton waits 2 seconds before attacking again
    private int timeBetweenAttacks = 2;
    // Start is called before the first frame update
    void Start()
    {
        alreadyAttacked = false;
    }

    // Update is called once per frame
    void Update()
    {
       healthBar.value = health;

        if (animator.GetBool("isAttacking") == true)
        {
            AttackPlayer();
        }
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

    private void AttackPlayer()
    {
        //if the enemy hasnt already attacked
        if (!alreadyAttacked)
        {
            

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
