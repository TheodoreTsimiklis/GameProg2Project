using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuLoad : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField]
    private GameObject m_MainMenu;
    [SerializeField]
    private GameObject m_SettingsMenu;

    [Header("Selected Buttons")]
    [SerializeField]
    private GameObject m_BtnOnAwake;
    [SerializeField]
    private GameObject m_BtnGoToSettings;
    [SerializeField]
    private GameObject m_BtnBackToMain;
    // Start is called before the first frame update

    private void Awake()
    {
        if (m_SettingsMenu.TryGetComponent<SettingsMenuButtons>(out var script))
        {
            script.Load();
        }
        SetSelectedButton(m_BtnOnAwake);
    }

    public void SwitchToSettings()
    {
        m_MainMenu.SetActive(false);
        m_SettingsMenu.SetActive(true);
        SetSelectedButton(m_BtnGoToSettings);
    }

    public void SwitchToMain()
    {
        m_MainMenu.SetActive(true);
        m_SettingsMenu.SetActive(false);
        SetSelectedButton(m_BtnBackToMain);
    }

    private void SetSelectedButton(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button);
    }
}
