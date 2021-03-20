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
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private TimerDataSO _timerData;

    [Header("UI Menus and Attributes")]
    [SerializeField] private GameObject _gameEndMenu;
    [SerializeField] private GameObject _gamePauseMenu;
    [SerializeField] private Image[] _playersImageUI;
    [SerializeField] private Image _background;
    [SerializeField] private Text _timerText;
    [SerializeField] private Text _winnerText;

    private void Update()
    {
        _timerText.text = _timerData.Timer.ToString("F0");
    }

    public void EndGame()
    {
        _gameEndMenu.SetActive(true);
    }

    public void RestartGame()
    {
        _gameEndMenu.SetActive(false);
        _gameEvent.FireEvent("GameStarted");
    }

    public void PauseGame()
    {
        _gamePauseMenu.SetActive(true);
        _gameEvent.FireEvent("PauseGame");
    }

    public void ContinueGame()
    {
        _gamePauseMenu.SetActive(false);
        _gameEvent.FireEvent("ContinueGame");
    }
}
