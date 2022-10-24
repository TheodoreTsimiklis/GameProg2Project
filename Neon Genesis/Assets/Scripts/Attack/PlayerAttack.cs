using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject weapon;
    Animator[] sword;
    AudioSource hitSound;
    public bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        sword = weapon.GetComponents<Animator>();
        hitSound = weapon.GetComponent<AudioSource>();
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
        isAttacking = true;
        //activates the trigger in the animator
        sword[0].SetTrigger("Hit");
        if (!hitSound.isPlaying)
        {
            hitSound.Play();
        }

    }

}

    
