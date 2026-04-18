using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    public static PlayerSelection Instance;

    public string selectedClass;
    public string selectedRace;
    // public int bonusHealth;
    // public int bonusSpeed;
    // public int bonusDamage;

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
}