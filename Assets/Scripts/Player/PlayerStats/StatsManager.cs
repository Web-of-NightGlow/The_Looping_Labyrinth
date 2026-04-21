using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    public StatsUI statsUI;

    [Header("Combat Stats")]
    public int damage;
    public float weaponRange;
    public float attackCooldown;
    public bool statsInitialized = false;
    public int baseHealth = 10;
    public int baseSpeed = 5;
    public int baseDamage = 1;

    [Header("Movement Stats")]
    public int moveSpeed;
    
    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;

    //[Header("Dexterity Stats")]
    //public int dexterity;


        void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
    }

    // public void UpdateAttackSpeed(float amount)
    // {
    //     attackCooldown -= amount;
    //     statsUI.UpdateAllStats();
    // }


    public void ResetStats()
    {
        maxHealth = baseHealth;
        currentHealth = maxHealth;
        moveSpeed = baseSpeed;
        damage = baseDamage;
    }
}
