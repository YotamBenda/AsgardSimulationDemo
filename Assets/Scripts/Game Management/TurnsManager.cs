using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnsManager : MonoBehaviour
{
    [Header("Game Setup")]
    [SerializeField] private EventTimer eventTimer;
    [SerializeField] private float timeForTurn = 30f;
    [SerializeField] private float turnEndBuffer = 3f;

    [Header("Game Events")]
    [SerializeField] UnityEvent TurnEnded;

    public void StartNewTurn()
    {
        eventTimer.TimeEvent(timeForTurn, TurnEnded);
        GameEventSubscriber.Instance.OnTestEvent += NextTurnAfterAttack;
    }

    public void NextTurnAfterAttack()
    {
        eventTimer.SetNewTimer(turnEndBuffer);
    }
}
