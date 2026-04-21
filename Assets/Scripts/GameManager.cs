using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public DialogueManager dialogueManager;
    public GameOverScript gameOverScript;
    public WinScreen winScreen;

    [Header("Persistant Objects")]
    public GameObject[] persistantObjects;

    private void Awake()
    {
        if(Instance != null)
        {
            CleanUpAndDestroy();
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            MarkPersistantObjects();
        }
    }


    private void MarkPersistantObjects()
    {
        foreach (GameObject obj in persistantObjects)
        {
            if(obj != null)
            {
                DontDestroyOnLoad(obj);
            }
        }
    }


    private void CleanUpAndDestroy()
    {
        foreach (GameObject obj in persistantObjects)
        {
            if(obj != null)
            {
                Destroy(obj);
            }
        }
        Destroy(gameObject);
    }


    public void StartNewGame()
    {
        if (PlayerSelection.Instance != null)
        {
            PlayerSelection.Instance.hasAppliedStats = false;
        }

        if (StatsManager.Instance != null)
        {
            StatsManager.Instance.ResetStats();
        }
    }


    public void GameOver()
    {
        if (gameOverScript != null)
        {
            gameOverScript.SetUp();
        }
        else
        {
            Debug.LogError("GameOverScript not assigned!");
        }
    }


    public void WinGame()
    {
        if (winScreen != null)
        {
            winScreen.Show();
        }
    }
}
