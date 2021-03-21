using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameplayManager :  GenericSingleton<GameplayManager>
{
    public GameplayManager()
    {
        Player = player;
        Score = 0;
    }

    public int Score { get; set; }
    public Actor Player { get; private set; }

    [Header("Scene Setup")]
    [SerializeField] GameEvent gameEvent;
    [SerializeField] EventTimer eventTimer;
    [SerializeField] TimerDataSO timerDataSO;
    [SerializeField] Actor player;

    [Header("Game Events")]
    [SerializeField] UnityEvent MatchEnded;

    private void Start()
    {
        eventTimer.TimeEvent(timerDataSO.TimeForGame, MatchEnded);
    }

    public void OnActorDied(Actor actor)
    {
        Score++;
        gameEvent.FireEvent("EnemyKilled");
    }

    public void OnMatchEnded()
    {
        gameEvent.FireEvent("MatchEnded");
    }
}
