using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public bool IsSound = true;
    public int CountCoin;
    public int CountGem;
    public List<int> ShopWeapons;
    public int Level;
    public int LocalizationIndex;
    public bool IsReview;
    public GameData(Game data)
    {
        IsSound = data.IsSound;
        CountCoin = data.CountCoin;
        CountGem = data.CountGem;
        Level = data.Level;
        LocalizationIndex = data.LocalizationIndex;
        IsReview = data.IsReview;
    }

 
}
