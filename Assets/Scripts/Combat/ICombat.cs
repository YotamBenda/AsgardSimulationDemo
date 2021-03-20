public interface ICombat
{
    string UniqueID { get; }
    void Attack();
    void TakeDamage(float amount, WeaponSO.DamageType damageType);
    void Die();
}
