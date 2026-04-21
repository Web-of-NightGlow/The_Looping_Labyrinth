using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public RoomController room;
    public int currentHealth = 4;
    public int maxHealth = 4;
    public GameObject popUpPrefab;


    void Awake()
    {
        room = GetComponentInParent<RoomController>();
    }


    private void Start()
    {
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
        Debug.Log(gameObject.name + " died");
        room.EnemyDied(gameObject);

        if (CompareTag("Boss"))
        {
            BossMemory.Instance?.SavePlayerStats();
            GameManager.Instance?.WinGame();
        }

        Destroy(gameObject);
    }

    void OnDestroy()
    {
        Debug.Log(gameObject.name + " UI element destroyed!");
    }
}
