using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour, Observer
{
    Animator sword;
    private int playerHealth = 100;
    public AudioSource hitSound;
    public AudioClip hitClip;
    public AudioClip longClip;
    public bool isAttacking = false;
    int currentAttackType = 1; // 1 for short swing, 2 for long swing
    public Slider healthBar;
    public Slider staminahBar;
    public float stamina;
    float maxStamina;
    public float dvalue;
    private float hundred;

    private PlayerStats m_Stats;
    private int m_CurrentMaxHealth;

    // Start is called before the first frame update
    void Start()
    {
        sword = GetComponent<Animator>();
        hitSound = GetComponent<AudioSource>();
        maxStamina = stamina;
        staminahBar.maxValue = maxStamina;
        m_Stats = GetComponent<PlayerStats>();
        playerHealth = m_CurrentMaxHealth = m_Stats.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //health bar reflects the players health
        healthBar.value = playerHealth;

        if (!Input.GetKeyDown(KeyCode.Mouse1))
        {
            IncreaseStamina();
            staminahBar.value = stamina;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SwordShortAttack();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)) // This if statement will decrease the the stamina of the player
        {
            DecreaseStamina();
        if(staminahBar.value < 50) {
            isAttacking = true;
        } else {
            isAttacking = false;
        }

            staminahBar.value = stamina;
            SwordLongAttack(currentAttackType); 
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

    public void SwordLongAttack(int hitAttackNumber)
    {
        if (isAttacking == false)
        {
            currentAttackType = hitAttackNumber;
            Debug.Log("The value " + currentAttackType);
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

    /**
    * This function decreases the stamina of the player
    */
    private void DecreaseStamina() 
    {
        if(stamina != 0) 
        {
            Debug.Log("pleace" + stamina);
            stamina -= dvalue;
        } else {
            // The player must wait until his stamina increases
        }

        if (stamina < 0) //This if statement will set the value of the stamina back to 0 if ever goes under 0
        {
            stamina = 0;
        }
    }

    /**
    * This function increases the stamina of the player
    */
    private void IncreaseStamina() 
    {
        if (stamina <= 100) {
            stamina += 30 * Time.deltaTime;
        } else {
            Debug.Log("pleace" + stamina);
        }

        if (stamina > 100) //This if statement will set the value of the stamina back to 100 if ever goes under 0
        {
            stamina = 100;
        }
    }

    /**
    * This function allows the player to take a specific amount of damage
    */
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            //game over
            Debug.Log("PLAYER DEAD");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }
    }

    public void SubjectUpdate()
    {
        playerHealth += m_Stats.MaxHealth - m_CurrentMaxHealth;
        m_CurrentMaxHealth = m_Stats.MaxHealth;
    }
}
