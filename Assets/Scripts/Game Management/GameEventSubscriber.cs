using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// GameEventSubscriber is used on any GameObject that wants to be subscried to the main Game Event system.
/// All events are exposed to the inspector, assigning through it which function to activate for each event fired.
/// Firing events from GameEvent class, using the Enums names in this class.
/// </summary>
public class GameEventSubscriber : MonoBehaviour
{
    public UnityEvent OnGameStarted;
    public UnityEvent OnGameEnded;
    public UnityEvent OnEnemyKilled;

    public void OnEventFired(string eventName)
    {
        StartCoroutine(eventName);
    }
    public IEnumerator GameStart()
    {
        OnGameStarted?.Invoke();
        yield return null;
    }
    public IEnumerator GameEnded()
    {
        OnGameEnded?.Invoke();
        yield return null;
    }
    public IEnumerator EnemyKilled()
    {
        OnEnemyKilled?.Invoke();
        yield return null;
    }
}
