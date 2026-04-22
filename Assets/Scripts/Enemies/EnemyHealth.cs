using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public RoomController room;
    public int currentHealth = 4;
    public int maxHealth = 4;
    public GameObject popUpPrefab;
    AudioManager audioManager;


    void Awake()
    {
        room = GetComponentInParent<RoomController>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    private void Start()
    {
        if (CompareTag("Boss") && BossMemory.Instance != null && BossMemory.Instance.hasData)
        {
            maxHealth = BossMemory.Instance.savedHealth;
        }

        currentHealth = maxHealth;
    }


    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        GameObject popUp = Instantiate(popUpPrefab, transform.position, Quaternion.identity);
        popUp.GetComponentInChildren<TMP_Text>().text = amount.ToString();

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        room.EnemyDied(gameObject);
        audioManager.PlaySFX(audioManager.enemyDeathClip);

        if (CompareTag("Boss"))
        {
            BossMemory.Instance?.SavePlayerStats();
            GameManager.Instance?.WinGame();
        }

        Destroy(gameObject);
    }
}
