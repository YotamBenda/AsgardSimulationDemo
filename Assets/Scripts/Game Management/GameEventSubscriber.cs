using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// GameEventSubscriber is used on any GameObject that wants to be subscried to the main Game Event system.
/// All events are exposed to the inspector, assigning through it which function to activate for each event fired.
/// Firing events from GameEvent class, using the Enums names in this class.
/// </summary>
public class GameEventSubscriber : GenericSingleton<GameEventSubscriber>
{
    [SerializeField] GameEvent gameEvent;

    public delegate void TestEvent();
    public event TestEvent OnTestEvent;
    public UnityEvent OnMatchStarted;
    public UnityEvent OnMatchEnded;
    public UnityEvent OnMatchRestarted;
    public UnityEvent OnEnemyKilled;


    public void InvokeTestEvent()
    {
        OnTestEvent?.Invoke();
    }
    public void OnEventFired(string eventName)
    {
        StartCoroutine(eventName);
    }

    public IEnumerator MatchStart()
    {
        OnMatchStarted?.Invoke();
        yield return null;
    }

    public IEnumerator MatchEnded()
    {
        OnMatchEnded?.Invoke();
        yield return null;
    }

    public IEnumerator MatchRestarted()
    {
        OnMatchRestarted?.Invoke();
        yield return null;
    }

    public IEnumerator EnemyKilled()
    {
        OnEnemyKilled?.Invoke();
        yield return null;
    }

    private void OnEnable()
    {
        gameEvent += this;
    }

    private void OnDisable()
    {
        gameEvent -= this;
    }
}
