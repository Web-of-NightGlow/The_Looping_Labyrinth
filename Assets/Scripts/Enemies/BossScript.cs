using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int damage = 5;
    public int moveSpeed = 2;
    public int maxHealth = 30;
    public int currentHealth;

    void Start()
    {
        if (BossMemory.Instance != null && BossMemory.Instance.hasData)
        {
            damage = BossMemory.Instance.savedDamage;
            moveSpeed = BossMemory.Instance.savedSpeed;
            maxHealth = BossMemory.Instance.savedHealth;

            currentHealth = maxHealth;

            Debug.Log("Boss loaded previous player stats!");
        }
    }

    void Die()
    {
        BossMemory.Instance.SavePlayerStats();

        GameManager.Instance.WinGame(); // we'll make this next

        Destroy(gameObject);
    }
}
