using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public Slider slider;
    public GameObject popUpPrefab;
    public bool isInvulnerable = false;

    void Start()
    {
        StatsManager.Instance.currentHealth = StatsManager.Instance.maxHealth;
        slider.maxValue = StatsManager.Instance.maxHealth;
        slider.value = StatsManager.Instance.currentHealth;
    }


    public void ChangeHealth(int amount)
    {
        if (amount < 0 && isInvulnerable)
        {
            Debug.Log("Blocked damage with Holy Armor");
            return;
        }

        StatsManager.Instance.currentHealth += amount;

        GameObject popUp = Instantiate(popUpPrefab, transform.position, Quaternion.identity);
        popUp.GetComponentInChildren<TMP_Text>().text = amount.ToString();

        slider.value = StatsManager.Instance.currentHealth;

        if (StatsManager.Instance.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
