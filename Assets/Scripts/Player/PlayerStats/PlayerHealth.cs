using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public Slider slider;
    public GameObject popUpPrefab;
    public bool isInvulnerable = false;
    AudioManager audioManager;

    void Start()
    {
        StatsManager.Instance.currentHealth = StatsManager.Instance.maxHealth;
        slider.maxValue = StatsManager.Instance.maxHealth;
        slider.value = StatsManager.Instance.currentHealth;
    }


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    void Update()
    {
        slider.maxValue = StatsManager.Instance.maxHealth;
        slider.value = StatsManager.Instance.currentHealth;
    }


    public void ChangeHealth(int amount)
    {
        if (amount < 0 && isInvulnerable)
        {
            return;
        }

        StatsManager.Instance.currentHealth += amount;

        GameObject popUp = Instantiate(popUpPrefab, transform.position, Quaternion.identity);
        popUp.GetComponentInChildren<TMP_Text>().text = amount.ToString();

        slider.value = StatsManager.Instance.currentHealth;

        if (StatsManager.Instance.currentHealth <= 0)
        {
            audioManager.PlaySFX(audioManager.playerDeathClip);
            GameManager.Instance.GameOver();

            gameObject.SetActive(false);
        }
    }
}
