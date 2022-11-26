using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int AttackDamage { get; private set; }
    public float CritChance { get; private set; }
    public int MaxHealth { get; private set; }
    public float Speed { get; private set; }

    public int AttackLevel { get; private set; } = 0;
    public int CritLevel { get; private set; } = 0;
    public int HealthLevel { get; private set; } = 0;
    public int SpeedLevel { get; private set; } = 0;

    public int Money { get; set; } = 1000;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Money = 1000;
            Debug.Log("Player given 1000 G");
        }
    }

    // NOTE: Probably change the scaling from Linear to Logarithmic later on.
    public void AttackLevelUp()
    {
        ++AttackLevel;
        AttackDamage = AttackScaling(AttackLevel);
    }

    public void CritLevelUp()
    {
        ++CritLevel;
        CritChance = CritScaling(CritLevel);
    }
    public void HealthLevelUp()
    {
        ++HealthLevel;
        MaxHealth = HealthScaling(HealthLevel);
    }
    public void SpeedLevelUp()
    {
        ++SpeedLevel;
        Speed = SpeedScaling(SpeedLevel);
    }

    public int AttackScaling(int level) => (int)StatScaling(1.1f, level, 10f);
    public float CritScaling(int level) => StatScaling(0.02f, level, 0.05f);
    public int HealthScaling(int level) => (int)StatScaling(5f, level, 200f);
    public float SpeedScaling(int level) => StatScaling(0.01f, level, 1f);

    private float StatScaling(float scale, int level, float baseVal) => scale * level + baseVal;
}
