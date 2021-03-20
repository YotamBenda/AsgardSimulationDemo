using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    
    public override void Attack()
    {
        base.Attack();
        //-- attack player

        ActorUtils.TriggerAttackAnimation(animator);

        //ActorUtils.Log(gameObject, "Attack");
        if (preferredWeapon == null)
        {
            ActorUtils.Log(gameObject, "NoWeapon");
            Debug.LogError("Enemy preferredWeapon must be defined");
        }

        Transform player  = GameplayManager.Instance.Player.transform;
        GameObject weapon = Instantiate(preferredWeapon, weaponSpawnPoint.position, Quaternion.identity);

        float shootingAngle = 30f;
        weapon.GetComponent<Rigidbody>().velocity = BallisticVelocity(player, shootingAngle);
    }

    private Vector3 BallisticVelocity(Transform target, float angle)
    {
        // https://answers.unity.com/questions/148399/shooting-a-cannonball.html
        var dir = target.position - transform.position;  // get target direction
        var h = dir.y;              // get height difference
        dir.y = 0;                  // retain only the horizontal direction
        var dist = dir.magnitude;   // get horizontal distance
        var a = angle * Mathf.Deg2Rad;  // convert angle to radians
        dir.y = dist * Mathf.Tan(a);  // set dir to the elevation angle
        dist += h / Mathf.Tan(a);   // correct for small height differences
                                    // calculate the velocity magnitude
        var vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return vel * dir.normalized;
    }

    public override void Die()
    {
        base.Die();
    }
}
