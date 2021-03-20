﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActorType { Player, Enemy };

[CreateAssetMenu(fileName = "Actor", menuName = "Actor")]
public class ActorSO : ScriptableObject
{
    [Header("Menu Display")]
    public string actorName;
    public string description;
    public Sprite icon;

    [Header("Misc")]
    public ActorType actorType;
    [Tooltip("Does this actor play?")]
    public bool canTakeTurn = true; 
    [Range(1, 5)]
    public int level = 1;

    [Header("Actor Lifecycle")]
    public bool respawnOnDie;

    [Header("Stats")]
    public float health;

    [Header("Effects")]
    public AudioSource idleAudio, attackAudio, takeDamageAudio, dieAudio, pickupWeaponAudio; // TODO: should there be one AS for all?
    
}
