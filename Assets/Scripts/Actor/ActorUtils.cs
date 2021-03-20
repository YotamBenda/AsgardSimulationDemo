using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorUtils
{

    static public void Log(GameObject gameObject, string msg)
    {
        //CustomDebugConsole.Log(gameObject.name, msg);
        //Debug.Log(gameObject.name + ": " + msg);
    }

    static public void Play(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    static public void TriggerAttackAnimation(Animator animator)
    {
        Animate(animator, "Attack");
    }
    static public void TriggerIdleAnimation(Animator animator)
    {
        Animate(animator, "Idle");
    }
    static public void TriggerTakeDamageAnimation(Animator animator)
    {
        Animate(animator, "TakeDamage");
    }
    static public void TriggerDieAnimation(Animator animator)
    {
        Animate(animator, "Die");
    }

    static public void Animate(Animator animator, string triggerName)
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerName);
        }
    }

    static public void Animate(Animator animator, string name, bool value)
    {
        if (animator != null)
        {
            animator.SetBool(name, value);
        }
    }
}
