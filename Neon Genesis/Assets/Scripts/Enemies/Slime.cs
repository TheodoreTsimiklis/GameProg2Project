using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Slime : MonoBehaviour
{
    private int health = 30;
    public GameObject slime;
    public Slider healthBar;
    public Animator animator;
    public AudioClip hit;
    private bool alreadyAttacked;
    private AudioSource audio;
    //the amount of seconds an enemy waits before attacking again
    private int timeBetweenAttacks = 2;
    private bool isAlive = true;

    //the players position
    private Transform player;

    //the amount of damage a slime does
    private int damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        alreadyAttacked = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
        float distance = Vector3.Distance(player.position, animator.transform.position);
        //attack if distance is less than 4
        if (distance < 4f)
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
            Destroy(slime, 2f);
        }
        else
        {
            //TODO: play enemy get hit animation


        }
    }

    private void AttackPlayer()
    {
        //if enemy has not already attacked
        if (!alreadyAttacked && isAlive == true)
        {
            animator.Play("Armature|Slime_Attack");
            audio.PlayOneShot(hit);
            //deal damage
            player.GetComponent<PlayerAttack>().TakeDamage(damage);
            alreadyAttacked = true;

            //allows the enemy to attack again in 2 seconds
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}

