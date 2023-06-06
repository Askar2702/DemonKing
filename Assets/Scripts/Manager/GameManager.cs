using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    [SerializeField] private GameObject _panelfinish;
    public bool isfinish;
    private void Awake()
    {
        if (!instance) instance = this;
    }
    public void Finish()
    {
        isfinish = true;
        _panelfinish.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
