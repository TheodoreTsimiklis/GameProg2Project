using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Threading.Tasks;

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
    private int timeBetweenAttacks = 3;
    private bool isAlive = true;
    private float attackingDistance = 4f;

    //distance between enemy and player
    private float distance;

    //the players position
    private Transform player;

    //the amount of damage a slime does
    private int damage = 4;
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
        distance = Vector3.Distance(player.position, animator.transform.position);
        //attack if distance is less than 4
        if (distance < attackingDistance)
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
            isAlive = false;
        }
    }

    private async void AttackPlayer()
    {
        //if enemy has not already attacked
        if (!alreadyAttacked && isAlive)
        {
            await Task.Delay(500);
            animator.Play("Armature|Slime_Attack");
            distance = Vector3.Distance(player.position, animator.transform.position);
            //if enemy is still in attacking range after half a second, deal damage
            if (distance < attackingDistance)
            {
                while (!alreadyAttacked && isAlive)
                {
                    audio.PlayOneShot(hit);
                    //deal damage
                    Debug.Log("damage done");
                    player.GetComponent<PlayerAttack>().TakeDamage(damage);
                    Invoke(nameof(ResetAttack), timeBetweenAttacks);
                    alreadyAttacked = true;

                }

            }
            //check again if enemy is still alive before playing animation
            if (isAlive)
            {
                animator.Play("ackletonArmature|Skeleton_Attack");
            }
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}

