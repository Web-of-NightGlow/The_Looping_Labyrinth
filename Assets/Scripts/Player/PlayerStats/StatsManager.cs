using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    public StatsUI statsUI;

    [Header("Combat Stats")]
    public int damage;
    public float weaponRange;
    public float attackCooldown;

    [Header("Movement Stats")]
    public int moveSpeed;
    
    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;

    private void Awake()
{
    if (Instance == null)
    {
        Instance = this;
    }
    else
    {
        Destroy(gameObject);
    }
}

    public void UpdateMaxHealth(int amount)
    {
        maxHealth += amount;
        currentHealth = maxHealth;
    }

    public void UpdateSpeed(int amount)
    {
        moveSpeed += amount;
    }

    public void UpdateStrength(int amount)
    {
        damage += amount;
        statsUI.UpdateAllStats();
    }
}
