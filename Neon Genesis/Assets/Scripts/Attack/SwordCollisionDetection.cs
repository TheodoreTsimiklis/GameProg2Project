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
        //EnemyTest enemy = other.GetComponent<EnemyTest>();

        if (other.tag == "Dragon" && pl.isAttacking)
        {
            //reduce the enemys health once hit
            other.GetComponent<Dragon>().TakeDamage(doDamage());
            
        }else if (other.tag == "Skeleton" && pl.isAttacking)
        {
            other.GetComponent<Skeleton>().TakeDamage(doDamage());
        }
    }

    int doDamage()
    {
        if (Random.Range(0,5) == 4)
        {
            //1/4 chance of dealing crit hit
            damageDone = 10;
        }
        else
        {
            damageDone = 20;
        }

        return (int)damageDone;
    }

    
}
