using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    public static Game instance;
    private bool _isSound;

    private int _countCoin;
    private int _countGem;
    private int _level;
    private int _localizationIndex;
    private bool _isReview;

   
 
    public bool IsSound
    {
        get
        {
            return _isSound;
        }
        set
        {
            if (_isSound != value)
            {
                _isSound = value;
                SaveData();
            }
        }
    } 
    
    public bool IsReview
    {
        get
        {
            return _isReview;
        }
        set
        {
            if (_isReview != value)
            {
                _isReview = value;
                SaveData();
            }
        }
    }


   

    public int CountCoin
    {
        get
        {
            return _countCoin;
        }
        set
        {
            if (_countCoin != value)
            {
                _countCoin = value;
                SaveData();
            }
        }
    }
    
    public int CountGem
    {
        get
        {
            return _countGem;
        }
        set
        {
            if (_countGem != value)
            {
                _countGem = value;
                SaveData();
            }
        }
    }

   

    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            if (_level != value)
            {
                _level = value;
                SaveData();
            }
        }
    }


   

   

 
    
    public int LocalizationIndex
    {
        get
        {
            return _localizationIndex;
        }
        set
        {
            if (_localizationIndex != value)
            {
                _localizationIndex = value;
                if (_localizationIndex >= 2) _localizationIndex = 2;
                if (_localizationIndex < 0) _localizationIndex = 0;
                SaveData();
            }
        }
    }

    private void Awake()
    {
        if (!instance) instance = this;
         print(Application.persistentDataPath);
        LoadData();
    }

    private void SaveData()
    {
        SaveSystem.SaveData(this);
    }
    private void LoadData()
    {
        GameData data = SaveSystem.LoadData();
        if(data!=null)
        {
            _isSound = data.IsSound;
            _countCoin = data.CountCoin;
            _level = data.Level;
            _localizationIndex = data.LocalizationIndex;
            _isReview = data.IsReview;
        }
    }

}
