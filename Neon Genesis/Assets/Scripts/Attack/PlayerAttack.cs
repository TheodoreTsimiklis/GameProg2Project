using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    Animator sword;
    private int playerHealth = 100;
    public AudioSource hitSound;
    public AudioClip hitClip;
    public AudioClip longClip;
    public bool isAttacking = false;
    int currentAttackType = 1; // 1 for short swing, 2 for long swing
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        sword = GetComponent<Animator>();
        hitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //health bar reflects the players health
        healthBar.value = playerHealth;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            SwordShortAttack();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

            SwordLongAttack();
        }

    }
    public void SwordShortAttack()
    {
        //if the player is not already attacking
        if (isAttacking == false)
        {
            currentAttackType = 1;
            sword.enabled = true;
            sword.Play("arm_swing");
            isAttacking = true;

        }

    }

    public void SwordLongAttack()
    {
        if (isAttacking == false)
        {
            currentAttackType = 2;
            sword.enabled = true;
            sword.Play("long_swing");
            isAttacking = true;
        }


    }

    //sets the player's isAttacking back to false at the end of the attack animation
    public void doneAttacking()
    {
        isAttacking = false;
    }

    public void playHitSound()
    {
        //play the right sound for the right attack
        if (currentAttackType == 1)
        {
            hitSound.PlayOneShot(hitClip);
        }
        else if (currentAttackType == 2)
        {
            hitSound.PlayOneShot(longClip);
        }


    }

}

