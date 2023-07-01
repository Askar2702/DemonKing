using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelUpUnits", menuName = "LevelUp", order = 1)]

public class LevelUpUnits : ScriptableObject
{
    public UpDataUnit[] UpDataUnits;
}

[Serializable]
public class UpDataUnit
{
    public string NameUnit;
    public int[] UpgradePriceså;
    public int LimitUpgradeDamage;
    public int LimitUpgradeAttackSpeed;
    public int LimitUpgradeMoveSpeed;
    public int LimitUpgradeHealth;
    public float ExperienceMultiplier;
}

