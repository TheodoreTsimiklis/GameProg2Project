using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator sword;
    public AudioSource hitSound;
    public AudioClip hitClip;
    public bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        sword = GetComponent<Animator>();
        hitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   

        if (Input.GetKeyDown(KeyCode.Mouse0)){

           SwordAttack();
        }
            
    }
    public void SwordAttack()
    {
        sword.enabled = true;
        sword.Play("arm_swing");
        isAttacking = true;

    }

    //sets the player's isAttacking back to false at the end of the attack animation
    public void doneAttacking()
    {
        isAttacking = false;
    }

    public void playHitSound()
    {
        hitSound.PlayOneShot(hitClip);
    }

}

    
