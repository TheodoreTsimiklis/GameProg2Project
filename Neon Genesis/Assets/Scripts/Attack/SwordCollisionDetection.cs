using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollisionDetection : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Player;
    private PlayerStats m_PlayerStats;
    public PlayerAttack pl;
    float damageDone;

    void Awake()
    {
        m_PlayerStats = m_Player.GetComponent<PlayerStats>();
    }

    public void OnTriggerEnter(Collider other)
    {
        //get the enemys information
        //EnemyTest enemy = other.GetComponent<EnemyTest>();

        if (other.tag == "Dragon" && pl.isAttacking)
        {
            //reduce the enemys health once hit
            other.GetComponent<Dragon>().TakeDamage(doDamage());

        }
        else if (other.tag == "Skeleton" && pl.isAttacking)
        {
            other.GetComponent<Skeleton>().TakeDamage(doDamage());

        }
        else if (other.tag == "Slime" && pl.isAttacking)
        {
            other.GetComponent<Slime>().TakeDamage(doDamage());
        }
    }

    int doDamage()
    {
        var multiplier = 1f;
        if (Random.value < m_PlayerStats.CritChance)
        {
            multiplier = 1.5f;
        }

        int damageTaken = (int) (m_PlayerStats.AttackDamage * multiplier);
        Debug.Log(damageTaken);
        return damageTaken;
    }


}
