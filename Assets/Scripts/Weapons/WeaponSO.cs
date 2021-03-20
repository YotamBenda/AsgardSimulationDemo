using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon Common Attributes/Weapon")]
public class WeaponSO : ScriptableObject
{
    public enum WeaponUsage { SingleHand,  TwoHands, Throwable };
    public enum DamageType { Direct, Radius, Spray };

    [Header("Menu Display")]
    public string weaponName;
    public string description;
    public Sprite icon;


    [Header("Misc")]
    public WeaponUsage weaponUsage;
    public int goldCost;
    [Range(1, 5)]
    public int level = 1;

    [Header("Weapon Lifecycle")]
    public bool shouldWeaponDestructOnHit;
    public bool shouldWeaponResurect;
    
    [Header("Stats")]
    public float shotRange;
    public int damage;
    public DamageType damageType = DamageType.Direct;
    public int projectilesPerTap = 1;
    public float projectilesSpread = 0; // relevant if projectilesPerTap > 1

    [Header("Graphics")]
    public GameObject muzzleFlash;
    public GameObject hitGraphics;
    public GameObject weaponDestructionGraphics;
}
