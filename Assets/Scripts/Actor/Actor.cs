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

    private void Start()
    {
        currentHealth = staticData.health;
        SetCurrentHealthText();
        if(animator != null)
        {
            ActorUtils.TriggerIdleAnimation(animator);
        }
    }
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
 
    public virtual void Attack()
    {
        //ActorUtils.Play(staticData.attackAudio);
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
        else // using ActorUtils to "take a hit"
        {
            //ActorUtils.Play(staticData.takeDamageAudio);
            //ActorUtils.TriggerTakeDamageAnimation(animator);

            ActorUtils.Log(gameObject, "TakeDamage [" + amount + "]");
        }
    }

    public virtual void Die()
    {
        isDead = true;
        //ActorUtils.Play(staticData.dieAudio);
        //ActorUtils.TriggerDieAnimation(animator);

        GameplayManager.Instance.OnActorDied(this);
        Destroy(this.gameObject);
    }
}
