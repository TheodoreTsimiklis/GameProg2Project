using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Player;

    private movement m_PlayerMovement;
    private PlayerAttack m_PlayerAttack;

    void Awake()
    {
        m_PlayerMovement = m_Player.GetComponent<movement>();
        m_PlayerAttack = m_Player.GetComponent<PlayerAttack>();
    }

    public void OpenPauseMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        m_PlayerMovement.enabled = false;
        m_PlayerAttack.enabled = false;
        gameObject.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        m_PlayerMovement.enabled = true;
        m_PlayerAttack.enabled = true;
        gameObject.SetActive(false);
    }

    public void GotoMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1;
        m_PlayerMovement.enabled = true;
        m_PlayerAttack.enabled = true;
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
