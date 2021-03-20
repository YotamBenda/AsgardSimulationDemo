using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actor : MonoBehaviour, ICombat
{
    public ActorSO staticData;
    public Transform weaponSpawnPoint;
    [Tooltip("Idle, TakeDamage, Die, Attack")]
    public Animator animator; 
    [Tooltip("Weapon prefab")]
    public GameObject preferredWeapon; // until we define how an enemy picks up a weapon
    public Text healthText;


    public bool isDead { get; protected set; } = false;
    protected float currentHealth;

    string ICombat.UniqueID => GetInstanceID().ToString();

    [HideInInspector]
    public bool IsActorTurn { get; protected set; } = false;

    private void SetCurrentHealthText()
    {
        if (healthText != null)
        {
            if (currentHealth <= 0)
            {
                healthText.text = "";
            }
            else
            {
                healthText.text = currentHealth.ToString();
            }
        }
    }
    private void Start()
    {
        currentHealth = staticData.health;
        SetCurrentHealthText();
        //GameplayManager.Instance.OnActorSpawned(this);

        ActorUtils.TriggerIdleAnimation(animator);
    }
 
    public virtual void Attack()
    {
        ActorUtils.Play(staticData.attackAudio);
    }

    public virtual void TakeDamage(float amount, WeaponSO.DamageType damageType)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= amount;
        SetCurrentHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            ActorUtils.Play(staticData.takeDamageAudio);
            ActorUtils.TriggerTakeDamageAnimation(animator);

            ActorUtils.Log(gameObject, "TakeDamage [" + amount + "]");
        }
    }

    public virtual void Die()
    {
        isDead = true;
        ActorUtils.Play(staticData.dieAudio);
        ActorUtils.TriggerDieAnimation(animator);

        ActorUtils.Log(gameObject, "Died");

        // TODO: wait until animation is finished
        GameplayManager.Instance.OnActorDied(this);
    }
}
