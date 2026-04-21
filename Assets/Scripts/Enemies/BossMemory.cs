using UnityEngine;

public class BossMemory : MonoBehaviour
{
    public static BossMemory Instance;

    public int savedDamage;
    public int savedSpeed;
    public int savedHealth;

    public bool hasData = false;

    private void Awake()
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


    public void SavePlayerStats()
    {
        savedDamage = StatsManager.Instance.damage;
        savedSpeed = StatsManager.Instance.moveSpeed;
        savedHealth = StatsManager.Instance.maxHealth;

        hasData = true;

        Debug.Log("Boss absorbed player stats!");
    }
}