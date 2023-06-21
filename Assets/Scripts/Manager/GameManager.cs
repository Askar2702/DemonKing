using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public UnityEvent SendFinishSignal = new UnityEvent();
    public bool isfinish;
    private void Awake()
    {
        if (!instance) instance = this;
    }
    public void Finish()
    {
        isfinish = true;
        SendFinishSignal?.Invoke();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
