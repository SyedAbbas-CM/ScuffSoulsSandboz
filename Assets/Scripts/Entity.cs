using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float stamina = 100f;
    public float attackPower = 20f;
    public float defense = 10f;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        float damageToTake = damage - defense;
        if (damageToTake < 0) damageToTake = 0;

        currentHealth -= damageToTake;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Attack(CharacterStats target)
    {
        if (stamina > 0)
        {
            target.TakeDamage(attackPower);
            stamina -= 10; // Assuming each attack consumes 10 stamina
        }
    }

    private void Die()
    {
        // Handle death here (e.g., play animation, disable the character, etc.)
        Debug.Log(gameObject.name + " has died.");
    }
}
