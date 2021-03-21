﻿using System.Collections;
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
    [SerializeField] private GameObject gameEndMenu;
    [SerializeField] private GameObject gamePauseMenu;
    [SerializeField] private Text timerText;
    [SerializeField] private Text scoreText;


    private void Start()
    {
        SetScore();
    }

    private void Update()
    {
        timerText.text = timerData.Timer.ToString("F0");
    }

    public void EndGame()
    {
        //gameEndMenu.SetActive(true);
        Debug.Log("Game ended go to sleep");
    }

    public void RestartGame()
    {
        gameEndMenu.SetActive(false);
        gameEvent.FireEvent("GameStarted");
    }

    public void PauseGame()
    {
        gamePauseMenu.SetActive(true);
        gameEvent.FireEvent("PauseGame");
    }

    public void ContinueGame()
    {
        gamePauseMenu.SetActive(false);
        gameEvent.FireEvent("ContinueGame");
    }

    public void SetScore()
    {
        scoreText.text = GameplayManager.Instance.Score.ToString();
    }
}
