using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keeps the amount of time for each turn and the current timer.
/// <param name="Timer"> is updated through Timer Class.</param>
/// </summary>
[CreateAssetMenu(menuName = "Variables/TimerData", order = 3)]
public class TimerDataSO : ScriptableObject
{
    public float TimeForGame;
    public float Timer;
}
