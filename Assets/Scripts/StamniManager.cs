using UnityEngine;

public class StaminaManager : MonoBehaviour
{
    public float maxStamina;
    public float currentStamina;
    public float regenerationRate;

    private void Update()
    {
        RegenerateStamina();
    }

    public void ConsumeStamina(float amount)
    {
        currentStamina -= amount;
        if (currentStamina < 0) currentStamina = 0;
    }

    private void RegenerateStamina()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += regenerationRate * Time.deltaTime;
        }
    }
}