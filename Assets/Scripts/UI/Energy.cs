using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Energy : MonoBehaviour
{
    public static Energy instance { get; private set; }
    public float CurrentCountEnergy { get; private set; }
    private float _maxCountEnergy = 20f;
    private float _powerGenerationRate = 1.5f;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _textAmount;
    [SerializeField] private Warning _warning;
    private void Awake()
    {
        if (!instance) instance = this;
        _slider.onValueChanged.AddListener(ShowAmountEnergy);
    }

    private void Start()
    {
        CurrentCountEnergy = _maxCountEnergy;
        _slider.maxValue = _maxCountEnergy;
        _slider.value = CurrentCountEnergy;
    }
    private void Update()
    {
        if (_slider.value != _slider.maxValue)
        {
            CurrentCountEnergy += _powerGenerationRate * Time.deltaTime;
            _slider.value = CurrentCountEnergy;
        }
    }

    public bool BuyUnit(float amount)
    {
        if (amount <= CurrentCountEnergy)
        {
            CurrentCountEnergy -= amount;
            _slider.value = CurrentCountEnergy;
            return true;
        }
        else
        {
            _warning.Init();
            return false;
        }
    }

    private void ShowAmountEnergy(float value)
    {
        _textAmount.text = $"{value.ToString("f1")}/{_maxCountEnergy}";
    }
}
