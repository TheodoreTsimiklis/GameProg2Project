using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Player;
    private PlayerStats m_PlayerStats;

    void Start()
    {
        m_PlayerStats = m_Player.GetComponent<PlayerStats>();
    }

    public void ExitMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        m_Player.GetComponent<movement>().enabled = true;
        m_Player.GetComponent<PlayerAttack>().enabled = true;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ExitMenu();
        }
    }

    public void BuyAttack()
    {
        Debug.Log("Bought Attack");
        // Handler to increase player attack
    }

    public void BuyCrit()
    {
        Debug.Log("Bought Crit");
        // Handler to increase player crit
    }

    public void BuyHealth()
    {
        Debug.Log("Bought Health");
        // Handler to increase player health
    }

    public void BuySpeed()
    {
        Debug.Log("Bought Speed");
        // Handler to increase player speed
    }
}
