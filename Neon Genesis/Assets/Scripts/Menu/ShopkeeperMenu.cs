using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopkeeperMenu : MonoBehaviour, Observer
{
    private readonly static Color DisabledButton = new Color(0, ByteColorToFloat(90), ByteColorToFloat(125), ByteColorToFloat(150));
    private readonly static Color EnabledButton = new Color(0, ByteColorToFloat(174), ByteColorToFloat(242), ByteColorToFloat(150));
    private readonly static Color InsufficientText = new Color(ByteColorToFloat(255), ByteColorToFloat(81), ByteColorToFloat(13), ByteColorToFloat(255));

    [SerializeField]
    private GameObject m_Player;
    private PlayerStats m_PlayerStats;

    private bool purchased = false;

    private int BasePrice => 200;

    [Header("Upgrade Prompts")]
    [SerializeField]
    private TextMeshProUGUI AttackPrompt;
    [SerializeField]
    private TextMeshProUGUI CritPrompt;
    [SerializeField]
    private TextMeshProUGUI HealthPrompt;
    [SerializeField]
    private TextMeshProUGUI SpeedPrompt;

    [Header("Price Prompts")]
    [SerializeField]
    private TextMeshProUGUI AttackPrice;
    [SerializeField]
    private TextMeshProUGUI CritPrice;
    [SerializeField]
    private TextMeshProUGUI HealthPrice;
    [SerializeField]
    private TextMeshProUGUI SpeedPrice;
    [SerializeField]
    private TextMeshProUGUI PlayerMoney;

    [Header("Purchase Buttons")]
    [SerializeField]
    private GameObject AttackPurchaseButton;
    [SerializeField]
    private GameObject CritPurchaseButton;
    [SerializeField]
    private GameObject HealthPurchaseButton;
    [SerializeField]
    private GameObject SpeedPurchaseButton;

    void Awake()
    {
        m_PlayerStats = m_Player.GetComponent<PlayerStats>();
        m_PlayerStats.attach(this);
        SetMenuState();
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitMenu();
        }
    }

    public void BuyAttack()
    {
        int attackLevel = m_PlayerStats.AttackLevel;
        Purchase(attackLevel);
        m_PlayerStats.AttackLevelUp();
        Debug.Log($"Attack Damage: {m_PlayerStats.AttackDamage}");
    }

    public void BuyCrit()
    {
        int critLevel = m_PlayerStats.CritLevel;
        Purchase(critLevel);
        m_PlayerStats.CritLevelUp();
        Debug.Log($"Crit Chance: {m_PlayerStats.CritChance * 100}%");
    }

    public void BuyHealth()
    {
        int healthLevel = m_PlayerStats.HealthLevel;
        Purchase(healthLevel);
        m_PlayerStats.HealthLevelUp();
        Debug.Log($"Max Health: {m_PlayerStats.MaxHealth}");
    }

    public void BuySpeed()
    {
        int speedLevel = m_PlayerStats.SpeedLevel;
        Purchase(speedLevel);
        m_PlayerStats.SpeedLevelUp();
        Debug.Log($"Speed Multiplier: {m_PlayerStats.Speed}");
    }

    private void SetButtonState(GameObject button, int statLevel)
    {
        var buttonImage = button.GetComponent<Image>();
        var buttonButton = button.GetComponent<Button>();
        if (IsPurchaseable(statLevel))
        {
            buttonImage.color = EnabledButton;
            buttonButton.interactable = true;
        }
        else
        {
            buttonImage.color = DisabledButton;
            buttonButton.interactable = false;
        }
    }

    private void SetPriceState(TextMeshProUGUI text, int statLevel)
    {
        if (IsPurchaseable(statLevel))
        {
            text.color = Color.white;
        }
        else
        {
            text.color = InsufficientText;
        }

        text.text = $"{CalculatePrice(statLevel)} G";
    }

    private void Purchase(int statLevel)
    {
        m_PlayerStats.Money -= CalculatePrice(statLevel);
    }

    private void SetPromptsState()
    {
        int attackLevel = m_PlayerStats.AttackLevel;
        int critLevel = m_PlayerStats.CritLevel;
        int healthLevel = m_PlayerStats.HealthLevel;
        int speedLevel = m_PlayerStats.SpeedLevel;

        AttackPrompt.text = $"{m_PlayerStats.AttackScaling(attackLevel)}→{m_PlayerStats.AttackScaling(attackLevel + 1)}";
        CritPrompt.text = $"{m_PlayerStats.CritScaling(critLevel) * 100}%→{m_PlayerStats.CritScaling(critLevel + 1) * 100}%";
        HealthPrompt.text = $"{m_PlayerStats.HealthScaling(healthLevel)}→{m_PlayerStats.HealthScaling(critLevel + 1)}";
        SpeedPrompt.text = $"{m_PlayerStats.SpeedScaling(speedLevel)}→{m_PlayerStats.SpeedScaling(speedLevel + 1)}";

        SetPriceState(AttackPrice, attackLevel);
        SetPriceState(CritPrice, critLevel);
        SetPriceState(HealthPrice, healthLevel);
        SetPriceState(SpeedPrice, speedLevel);
        PlayerMoney.text = $"{m_PlayerStats.Money} G";
    }

    private void SetButtonsState()
    {
        SetButtonState(AttackPurchaseButton, m_PlayerStats.AttackLevel);
        SetButtonState(CritPurchaseButton, m_PlayerStats.CritLevel);
        SetButtonState(HealthPurchaseButton, m_PlayerStats.HealthLevel);
        SetButtonState(SpeedPurchaseButton, m_PlayerStats.SpeedLevel);
    }

    private void SetMenuState()
    {
        SetPromptsState();
        SetButtonsState();
    }

    private bool IsPurchaseable(int statLevel) => m_PlayerStats.Money >= CalculatePrice(statLevel);

    // Probably change this into a quadratic scaling later on.
    private int CalculatePrice(int statLevel) => (int)((.25f * statLevel + 1) * BasePrice);


    private static float ByteColorToFloat(byte color) => color / 255f;

    public void SubjectUpdate()
    {
        SetMenuState();
    }
}
