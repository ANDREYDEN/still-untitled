using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GameManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject InGameUI;
    public GameObject EndLevelMenu;

    public static float TimeScale { get; set; } = 1;

    [Inject] private SignalBus _signalBus;

    private void Start()
    {
        _signalBus.Subscribe<GameEnded>(HandleGameEnded);
    }

    private void HandleGameEnded(GameEnded result)
    {
        InGameUI.SetActive(false);
        EndLevelMenu.SetActive(true);
        Text label = EndLevelMenu.gameObject.GetComponentInChildren<Text>();
        label.text = result.won ? "Lucky winner!" : "Foolish looser!";
    }

    public void StartLevel()
    {
        MainMenu.SetActive(false);
        InGameUI.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
