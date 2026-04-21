using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    public static PlayerSelection Instance;

    public string selectedClass;
    public string selectedRace;
    public bool hasAppliedStats = false;

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