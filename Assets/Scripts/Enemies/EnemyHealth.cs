using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth = 4;
    public int maxHealth = 4;
    public GameObject popUpPrefab;

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
            Destroy(gameObject);
        }
    }
}
