using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossScript : MonoBehaviour
{
    public int damage = 5;
    public int moveSpeed = 2;
    public int maxHealth = 30;
    public int currentHealth;
    public GameObject popUpPrefab;

    void Start()
    {
        if (BossMemory.Instance != null && BossMemory.Instance.hasData)
        {
            damage = BossMemory.Instance.savedDamage + 2;
            moveSpeed = BossMemory.Instance.savedSpeed;
            maxHealth = BossMemory.Instance.savedHealth + 10;

            currentHealth = maxHealth;

            Debug.Log("Boss loaded previous player stats!");
        }
    }
}
