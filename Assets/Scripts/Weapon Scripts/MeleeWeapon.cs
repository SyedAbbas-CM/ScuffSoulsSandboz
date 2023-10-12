public class MeleeWeapon : WeaponBase
{
    public enum AttackType { Light, Heavy, Special }
    public float attackSpeed;
    public float range;
    public float staminaConsumption;

    public override void Equip()
    {
        // Logic to equip the weapon
    }

    public override void Unequip()
    {
        // Logic to unequip the weapon
    }

    public override void Attack()
    {
        // Logic for a basic attack
    }

    public void HeavyAttack()
    {
        // Logic for a heavy attack
    }

    public void SpecialAttack()
    {
        // Logic for a special attack or move unique to the weapon
    }
}