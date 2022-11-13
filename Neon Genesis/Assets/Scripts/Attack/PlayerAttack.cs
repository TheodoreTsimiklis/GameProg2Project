using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator sword;
    AudioSource hitSound;
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

    }

}

    
