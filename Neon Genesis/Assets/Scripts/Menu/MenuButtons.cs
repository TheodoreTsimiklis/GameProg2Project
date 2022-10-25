using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    readonly int[][] RESOLUTIONS = new[] { new[] { 1920, 1080 }, new[] { 1600, 900 }, new[] { 1366, 768 }, new[] { 1280, 720 } };
    readonly string[] INPUT_DEVICES = new[] {"Keyboard + Mouse", "Controller"};

    public Texture2D m_Fullscreen;
    public Texture2D m_Windowed;
    Sprite m_FullscreenSprite;
    Sprite m_WindowedSprite;

    public TextMeshProUGUI m_ResolutionText;
    public TextMeshProUGUI m_InputText;
    public Image m_FullScreenToggle;
    public Slider m_VolumeSlider;

    int m_CurrentRes;
    int m_CurrentInput;
    bool m_IsFullscreen;
    float m_CurrentVolume;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResolutionRightButton()
    {
        NewResolution(1);
    }

    public void ResolutionLeftButton()
    {
        NewResolution(-1);
    }

    private void NewResolution(int add)
    {
        m_CurrentRes = Mod(m_CurrentRes + add, RESOLUTIONS.Length);
        PlayerPrefs.SetInt("Resolution", m_CurrentRes);
        PlayerPrefs.Save();
        var res = RESOLUTIONS[m_CurrentRes];
        m_ResolutionText.text = ResolutionToString(res);
    }

    private string ResolutionToString(int[] res) => $"{res[0]}x{res[1]}";

    public void ToggleFullscreen()
    {
        m_IsFullscreen = !m_IsFullscreen;
        PlayerPrefs.SetInt("Fullscreen", m_IsFullscreen ? 1 : 0);
        PlayerPrefs.Save();
        m_FullScreenToggle.sprite = m_IsFullscreen ? m_FullscreenSprite : m_WindowedSprite;
        SetScreen();
    }

    private void SetScreen()
    {
        var res = RESOLUTIONS[m_CurrentRes];
        var fullScreenMode = m_IsFullscreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        Screen.SetResolution(res[0], res[1], fullScreenMode);
    }

    public void VolumeControl()
    {
        SetVolume();
        Debug.Log(AudioListener.volume);
        PlayerPrefs.SetFloat("Volume", m_VolumeSlider.value);
        PlayerPrefs.Save();
    }

    private void SetVolume()
    {
        AudioListener.volume = m_VolumeSlider.value;
    }

    public void InputRightButton()
    {
        NewInputDevice(1);
    }

    public void InputLeftButton()
    {
        NewInputDevice(-1);
    }

    public void NewInputDevice(int add)
    {
        m_CurrentInput = Mod(m_CurrentInput + add, INPUT_DEVICES.Length);
        PlayerPrefs.SetInt("InputDevice", m_CurrentInput);
        PlayerPrefs.Save();
        m_InputText.text = INPUT_DEVICES[m_CurrentInput];
    }

    static int Mod(int divisor, int dividend)
    {
        return (Math.Abs(divisor * dividend) + divisor) % dividend;
    }

    public void Load()
    {
        m_CurrentRes = PlayerPrefs.HasKey("Resolution") ? PlayerPrefs.GetInt("Resolution") : 0;
        m_CurrentInput = PlayerPrefs.HasKey("InputDevice") ? PlayerPrefs.GetInt("InputDevice") : 0;
        m_IsFullscreen = PlayerPrefs.HasKey("Fullscreen") ? PlayerPrefs.GetInt("Fullscreen") == 1 : false;
        m_CurrentVolume = PlayerPrefs.HasKey("Volume") ? PlayerPrefs.GetFloat("Volume") : 0f;

        SetScreen();
        SetVolume();

        m_FullscreenSprite = Sprite.Create(m_Fullscreen, new Rect(0, 0, m_Fullscreen.width, m_Fullscreen.height), Vector2.zero);
        m_WindowedSprite = Sprite.Create(m_Windowed, new Rect(0, 0, m_Windowed.width, m_Windowed.height), Vector2.zero);

        m_ResolutionText.text = ResolutionToString(RESOLUTIONS[m_CurrentRes]);
        m_InputText.text = INPUT_DEVICES[m_CurrentInput];
        m_FullScreenToggle.sprite = m_IsFullscreen ? m_FullscreenSprite : m_WindowedSprite;
        m_VolumeSlider.value = m_CurrentVolume;
    }
}
