using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEscapeHandling : MonoBehaviour
{
    [SerializeField]
    private GameObject m_ShopKeeperMenu;
    [SerializeField]
    private GameObject m_PauseMenu;
    [SerializeField]
    private GameObject m_SettingsMenu;

    void Awake()
    {
        var script = m_SettingsMenu.GetComponent<SettingsMenuButtons>();
        script.Load();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (m_ShopKeeperMenu.activeInHierarchy)
            {
                m_ShopKeeperMenu.GetComponent<ShopkeeperMenu>().ExitMenu();
            }
            else if (m_SettingsMenu.activeInHierarchy)
            {
                m_SettingsMenu.SetActive(false);
                m_PauseMenu.SetActive(true);
            }
            else if (m_PauseMenu.activeInHierarchy)
            {
                m_PauseMenu.GetComponent<PauseMenuScript>().ClosePauseMenu();
            }
            else
            {
                m_PauseMenu.SetActive(true);
                m_PauseMenu.GetComponent<PauseMenuScript>().OpenPauseMenu();
            }
        }
    }
}
