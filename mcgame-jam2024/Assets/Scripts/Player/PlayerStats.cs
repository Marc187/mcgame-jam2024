using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float initialSpeed = 5f;
    private float currentSpeed;
    private float maxSpeed = 10f;

    public float initialHealth = 100f;
    private float currentHealth;
    private float maxHealth;

    public float initialDamage = 10f;
    private float currentDamage;

    public HealthBar healthBar;

    private void Start()
    {
        // Initialize stats
        currentSpeed = initialSpeed;
        currentHealth = initialHealth;
        currentDamage = initialDamage;
        maxHealth = initialHealth;
        healthBar.SetMaxHealth(currentHealth);
        healthBar.SetInitialHealth(currentHealth);
    }

    // Increase Section
    public void IncreaseSpeed(float amount)
    {
        float newSpeed = currentSpeed += amount;
        if (newSpeed < maxSpeed )
        {
            currentSpeed += amount;
            Debug.Log("Player speed increased to: " + currentSpeed);
        }
    }

    public void IncreaseMaxHealth(float amount)
    {
        maxHealth += amount;
        healthBar.SetMaxHealth(maxHealth);
        Debug.Log("Player max health increased to: " + maxHealth);
    }

    public void IncreaseDamage(float amount)
    {
        currentDamage += amount;
        Debug.Log("Player damage increased to: " + currentDamage);
    }

    // Decrease Section
    public void DecreaseHealth(float amount)
    {
        float newHealth = currentHealth -= amount;
        if (newHealth <= 0)
        {
            HandleDeath();
        }
        healthBar.SetHealth(newHealth);
        Debug.Log("Player health decreased to: " + currentHealth);
    }

    // Death Section 
    private void HandleDeath()
    {
        // Perform any additional actions upon player death, such as playing an animation, showing a game over screen, etc.

        // Call the death handling logic from the PlayerDeath script
        PlayerDeath playerDeathScript = GetComponent<PlayerDeath>();
        if (playerDeathScript != null)
        {
            playerDeathScript.HandlePlayerDeath();
        }
    }

}
