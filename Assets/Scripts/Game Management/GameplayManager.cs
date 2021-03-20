using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager :  GenericSingleton<GameplayManager>
{
    public GameplayManager()
    {
        Player = player;
    }

    public int Score { get; set; }
    public Actor Player { get; private set; }

    [SerializeField] Actor player;

    public void OnActorDied(Actor actor)
    {
        Score++;
    }

    private void LoseGame()
    {
        
    }
}
