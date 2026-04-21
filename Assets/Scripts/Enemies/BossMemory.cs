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
            LoadData(); // LOAD ON START
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

        // SAVE TO DISK
        PlayerPrefs.SetInt("BossDamage", savedDamage);
        PlayerPrefs.SetInt("BossSpeed", savedSpeed);
        PlayerPrefs.SetInt("BossHealth", savedHealth);
        PlayerPrefs.SetInt("BossHasData", 1);

        PlayerPrefs.Save();

        Debug.Log("Boss stats saved to PlayerPrefs!");
    }


        void LoadData()
        {
            if (PlayerPrefs.GetInt("BossHasData", 0) == 1)
            {
                savedDamage = PlayerPrefs.GetInt("BossDamage");
                savedSpeed = PlayerPrefs.GetInt("BossSpeed");
                savedHealth = PlayerPrefs.GetInt("BossHealth");

                hasData = true;

                Debug.Log("Boss stats loaded from PlayerPrefs!");
            }
            else
            {
                hasData = false;
            }
        }
}