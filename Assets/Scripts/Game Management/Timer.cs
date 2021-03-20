using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Updates the timer for each turn, firing events accordingly.
/// </summary>
public class Timer : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private GameEvent _gameEvent;
    
    public static float timer = 0;


    private bool _gamePaused = false;

    private void Start()
    {
        ResetTimer();
    }
    private void Update()
    {
        if (_gamePaused == false)
            RunTimer();
    }

    private void RunTimer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            _gameEvent.FireEvent("EndGame");
        }
    }
    public void ResetTimer()
    {

    }

    public void PauseTimer()
    {
        _gamePaused = true;
    }

    public void ContinueTimer()
    {
        _gamePaused = false;
    }
}
