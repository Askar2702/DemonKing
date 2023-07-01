using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "GameSetting", order = 1)]
public class LevelSetting : ScriptableObject
{
    public LevelData[] levelDatas;
}

[Serializable]
public class LevelData
{
    public float GemCount;
    public float CoinCount;
}

