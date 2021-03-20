using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager :  GenericSingleton<GameplayManager>
{
    #region Game Events
    [SerializeField] GameEvent GameStarted;
    [SerializeField] GameEvent GameEnded;
    [SerializeField] GameEvent TurnStarted;
    [SerializeField] GameEvent TurnEnded;
    [SerializeField] GameEvent PlayerLost;
    [SerializeField] GameEvent PlayerWon;

    [SerializeField] GameObject WinMenu;
    [SerializeField] GameObject LoseMenu;
    #endregion

    // ------ temporarily managed in the inspector
    [SerializeField] List<Actor> enemies = new List<Actor>();
    [SerializeField] Actor tempPlayer;

    // all actors subscribe to the GameplayManager on Start via OnActorSpawned
    // [HideInInspector]
    //public List<Actor> enemies { get; private set; } = new List<Actor>();
    // [HideInInspector]
    public Actor player { get; private set; }

    [HideInInspector]
    public ActorType CurrentActorTurn { get; private set; } = ActorType.Player;

    private int currentEnemyIndex = -1;
    private readonly object enemiesLock = new object();

    private bool isPlaying = false;

    private void Start()
    {
        //Debug.Log("GameplayManager Start");
        player = tempPlayer;
        StartCoroutine(AutoPlayTest()); // REMOVE THIS when opening via menu
    }

    private IEnumerator AutoPlayTest() // play without menu
    {
        yield return new WaitForSeconds(4);

        currentEnemyIndex = -1;
        isPlaying = false;
        CurrentActorTurn = ActorType.Player;

        Play();
    }

    public void Play()
    {
        if (isPlaying)
        {
            return;
        }

        isPlaying = true;
        GameStarted?.InvokeEvent();
    }
    // ------ temporarily managed in the inspector
    public void OnActorSpawned(Actor actor)
    {
        switch (actor.staticData.actorType)
        {
            case ActorType.Player:
                player = actor;

                //CustomDebugConsole.Log("player spawned");
                //Debug.Log("GameplayManager: player spawned");
                break;

            case ActorType.Enemy:
                lock (enemiesLock)
                {
                    enemies.Add(actor); // thread safe access
                    //CustomDebugConsole.Log("enemy spawned " + actor.name + " " + (enemies.Count - 1));
                    //Debug.Log("GameplayManager: enemy spawned " + actor.name);
                }
                break;
        }
    }

    public void OnActorDied(Actor actor)
    {
        switch(actor.staticData.actorType)
        {
            case ActorType.Player:
                LoseGame();
                break;

            case ActorType.Enemy:
                int indexToRemove = enemies.IndexOf(actor);
                if (indexToRemove >= 0)
                {
                    if (indexToRemove <= currentEnemyIndex)
                    {
                        // if dying enemy index is smaller than the current index,
                        // we need to decrement the current index it by one
                        currentEnemyIndex--;
                    }
                    // no need for lock. multiple enemies will not dies concurrently
                    enemies.RemoveAt(indexToRemove); 
                }
                break;
        }
    }

    private bool IsWin()
    {
        // bug fix
        if (enemies.Count == 0)
        {
            return true;
        }

        foreach (var enemy in enemies)
        {
            if (!enemy.isDead)
            {
                return false;
            }
        }

        return true;
    }

    private void LoseGame()
    {
        //CustomDebugConsole.Log("I Lost :(");
        isPlaying = false;

        if (LoseMenu != null)
        {
            LoseMenu?.SetActive(true);
        }
        
        GameEnded?.InvokeEvent();        
        PlayerLost?.InvokeEvent();
    }
}
