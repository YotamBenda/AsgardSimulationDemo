using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Managing all the Menus, UI buttons and texts.
/// </summary>
public class UIManager : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private TimerDataSO timerData;

    [Header("UI Menus and Attributes")]
    [SerializeField] private GameObject matchEndMenu;
    [SerializeField] private GameObject matchPauseMenu;
    [SerializeField] private GameObject matchOverlay;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private Text timerText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text scoreTextEnding;


    private void Start()
    {
        SetScore();
    }

    private void Update()
    {
        SetTimer();

        if (Input.GetKey(KeyCode.Tab))
        {
            controlsMenu.SetActive(true);
        }
        else
        {
            controlsMenu.SetActive(false);
        }
    }

    public void EndGame()
    {
        scoreTextEnding.text = scoreText.text;
        matchOverlay.SetActive(false);
        matchEndMenu.SetActive(true);
    }

    public void RestartGame()
    {
        matchEndMenu.SetActive(false);
        matchOverlay.SetActive(true);
        gameEvent.FireEvent("GameStarted");
    }

    public void PauseGame()
    {
        matchPauseMenu.SetActive(true);
        gameEvent.FireEvent("PauseGame");
    }

    public void ContinueGame()
    {
        matchPauseMenu.SetActive(false);
        gameEvent.FireEvent("ContinueGame");
    }

    public void SetScore()
    {
        scoreText.text = GameplayManager.Instance.Score.ToString();
    }

    private void SetTimer()
    {
        var timer = timerData.Timer;
        var minutes = Mathf.Floor(timer / 60);
        var seconds = Mathf.Floor(timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
