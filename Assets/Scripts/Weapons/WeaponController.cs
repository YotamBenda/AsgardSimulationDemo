using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    public LayerMask damageable;

    protected Transform origin;

    private void Start()
    {
        origin = transform;
    }

    protected void OnHit(Collider other, WeaponSO staticData, Vector3 hitPoint)
    {
        OnHit(other.gameObject, staticData, hitPoint);
    }

    protected void OnHit(GameObject other, WeaponSO staticData, Vector3 hitPoint)
    {
        Debug.Log(other.name);

        ICombat combat = other.GetComponentInChildren<ICombat>();
        if (combat != null)
        {
            Debug.Log("OnHit: " + other.name);

            combat.TakeDamage(staticData.damage, staticData.damageType);
        }
        else
        {
            Debug.Log("OnHit non-damageable:" + other.name);
        }

        if (staticData.hitGraphics != null)
        {
            GameObject hitGraphics = Instantiate(staticData.hitGraphics, hitPoint, Quaternion.Euler(0, 180, 0));
            Destroy(hitGraphics, 2f);
        }

        if (staticData.weaponDestructionGraphics != null)
        {
            GameObject graphics = Instantiate(staticData.weaponDestructionGraphics, hitPoint, Quaternion.identity);
            Destroy(graphics, 2f);
        }

        if (staticData.shouldWeaponDestructOnHit)
        {
            Destroy(gameObject);
        }
    }
}
