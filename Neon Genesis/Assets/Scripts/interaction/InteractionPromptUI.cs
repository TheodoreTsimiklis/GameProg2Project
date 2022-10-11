using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionPromptUI : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private TextMeshProUGUI promptText;

    private Camera _mainCam;

    private void Start() {
        _mainCam = Camera.main;
        uiPanel.SetActive(false);
    }

    private void LateUpdate() {
        var rotation = _mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);       
    }

    public bool isDisplayed = false;
    public void SetUp(string _promptText) {
        promptText.text = _promptText;
        uiPanel.SetActive(true);
        isDisplayed = true;
    }

    public void Close() {
        uiPanel.SetActive(false);
        isDisplayed = false;
    }
}
