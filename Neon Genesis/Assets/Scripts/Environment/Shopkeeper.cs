using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour, Interactable
{
    [SerializeField]
    private GameObject m_MenuPanel;
    [SerializeField]
    private GameObject m_Player;

    public string interactionPrompt => "";

    public bool Interact(Interactor interactor)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        m_Player.GetComponent<movement>().enabled = false;
        m_Player.GetComponent<PlayerAttack>().enabled = false;
        m_MenuPanel.SetActive(true);
        return false;
    }
}
