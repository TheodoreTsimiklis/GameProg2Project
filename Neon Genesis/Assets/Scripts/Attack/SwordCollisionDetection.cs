using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollisionDetection : MonoBehaviour
{
    public PlayerAttack pl;
    float damageDone;
    public void OnTriggerEnter(Collider other)
    {
        //get the enemys information
        EnemyTest enemy = other.GetComponent<EnemyTest>();

        if (other.tag == "Enemy" && pl.isAttacking)
        {
            //reduce the enemys health once hit
            enemy.health-= doDamage();
            Debug.Log(enemy.health + " health left");
            
        }
    }

    int doDamage()
    {
        if (Random.Range(0,5) == 4)
        {
            //1/4 chance of dealing crit hit
            damageDone = 4;
        }
        else
        {
            damageDone = 2;
        }

        return (int)damageDone;
    }

    //sets the player's isAttacking back to false at the end of the attack animation
    public void doneAttacking()
    {
        pl.isAttacking = false;
    }
}
