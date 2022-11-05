using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLoad : MonoBehaviour
{
    [SerializeField] private GameObject m_SettingsMenu;
    // Start is called before the first frame update
    private void Awake()
    {
        if (m_SettingsMenu.TryGetComponent<SettingsMenuButtons>(out var script))
        {
            script.Load();
        }
    }
}
