using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class FinishManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _finishPanel;
    [SerializeField] private TextMeshProUGUI _killCount;
    [SerializeField] private TextMeshProUGUI _losses;
    [SerializeField] private TextMeshProUGUI _spawnCount;
    [SerializeField] private TextMeshProUGUI _gemCount;
    [SerializeField] private TextMeshProUGUI _coinCount;

    private void Start()
    {
        GameManager.instance.SendFinishSignal.AddListener(FinishShow);
    }
    private void FinishShow()
    {
        _finishPanel.gameObject.SetActive(true);
        _finishPanel.DOFade(1, 4);
        _killCount.text = ListEnemy.instance.SpawnCount.ToString();
        _losses.text = ListPlayer.instance.LossesCount.ToString();
        _spawnCount.text = ListPlayer.instance.SpawnCount.ToString();
    }
}
