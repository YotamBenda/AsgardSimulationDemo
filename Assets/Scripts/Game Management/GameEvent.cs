using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used on any script that wants to fire/initiate an event.
/// Using the FireEvent(eventName) function, eventNames taken from the GameEventSubscriber class (Enums names).
/// </summary>
[CreateAssetMenu(menuName = "Events/Game Event", order = 2)]
public class GameEvent : ScriptableObject
{
    public List<GameEventSubscriber> subscribers = new List<GameEventSubscriber>();

    public void FireEvent(string eventName)
    {
        for (int i = 0; i < subscribers.Count; ++i)
        {
            subscribers[i].OnEventFired(eventName);
        }
    }
}
