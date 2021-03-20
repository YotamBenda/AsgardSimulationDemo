using UnityEngine;

public class CollisionBasedWeaponController : WeaponController
{
    public WeaponSO staticData;

    private void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleCollision(other.gameObject);
    }

    private void HandleCollision(GameObject other)
    {
        OnHit(other, staticData, other.transform.position);
    }
}
