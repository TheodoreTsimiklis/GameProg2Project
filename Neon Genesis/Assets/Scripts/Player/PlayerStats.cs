using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour, Subject
{
    public int AttackDamage { get; private set; } = 10;
    public float CritChance { get; private set; } = 0.05f;
    public int MaxHealth { get; private set; } = 100;
    public float Speed { get; private set; } = 0.3f;

    public int AttackLevel { get; private set; } = 0;
    public int CritLevel { get; private set; } = 0;
    public int HealthLevel { get; private set; } = 0;
    public int SpeedLevel { get; private set; } = 0;

    public int Money { get; set; } = 1000;

    private List<Observer> observers = new List<Observer>();

    // NOTE: Probably change the scaling from Linear to Logarithmic later on.
    public void AttackLevelUp()
    {
        ++AttackLevel;
        AttackDamage = AttackScaling(AttackLevel);
        notify();
    }

    public void CritLevelUp()
    {
        ++CritLevel;
        CritChance = CritScaling(CritLevel);
        notify();
    }
    public void HealthLevelUp()
    {
        ++HealthLevel;
        MaxHealth = HealthScaling(HealthLevel);
        notify();
    }
    public void SpeedLevelUp()
    {
        ++SpeedLevel;
        Speed = SpeedScaling(SpeedLevel);
        notify();
    }

    public int AttackScaling(int level) => (int)StatScaling(1.1f, level, 10f);
    public float CritScaling(int level) => StatScaling(0.02f, level, 0.05f);
    public int HealthScaling(int level) => (int)StatScaling(5f, level, 100f);
    public float SpeedScaling(int level) => StatScaling(0.005f, level, 0.3f);

    private float StatScaling(float scale, int level, float baseVal) => scale * level + baseVal;

    public void attach(Observer o)
    {
        observers.Add(o);
    }

    public void detach(Observer o)
    {
        observers.Remove(o);
    }

    public void notify()
    {
        foreach (var o in observers)
        {
            o.SubjectUpdate();
        }
    }
}
