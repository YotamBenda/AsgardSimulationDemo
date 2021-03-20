using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTimer : MonoBehaviour
{
    public UnityEvent TriggeredEvent;
    public bool IsRunning
    {
        get;
        private set;
    }

    public float TimeToInvoke
    {
        get;
        private set;
    }

    float _initialTime;
    float _speed = 1f;

    private void Update() 
    {
        if(IsRunning && TimeToInvoke > 0f)
        {
            DecreaseTimer();
        }

        if(IsRunning && TimeToInvoke == 0f)
        {
            InvokeAndReset();
        }
    }

    private void InvokeAndReset()
    {
        if(TriggeredEvent != null)
            {
                TriggeredEvent.Invoke();
                IsRunning = false;
                TimeToInvoke = 0f;
                TriggeredEvent = null;
            }
            else
            Debug.Log($"[Event Timer] Timer finished without an event to invoke");
    }

    public void TimeEvent(float time, UnityEvent timedEvent)
    {
        TriggeredEvent = timedEvent;
        IsRunning = true;
        _initialTime = time;
        TimeToInvoke = time;
    }

    public void SetNewTimer(float newTimer)
    {
        _initialTime = newTimer;
        TimeToInvoke = newTimer;
    }

    public void SetNewEvent(UnityEvent newEvent)
    {
        TriggeredEvent = newEvent;
    }

    void DecreaseTimer()
    {
        TimeToInvoke = Mathf.Max(TimeToInvoke -= _speed * Time.deltaTime, 0f);
    }

    public void SuspendTimer()
    {
        IsRunning = false;
    }

    public void ResumeTimer()
    {
        IsRunning = true;
    }
}
