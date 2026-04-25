using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public DialogueManager dialogueManager;
    public GameOverScript gameOverScript;
    public WinScreen winScreen;

    [Header("Persistant Objects")]
    public GameObject[] persistantObjects;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        MarkPersistantObjects();
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        dialogueManager = FindAnyObjectByType<DialogueManager>();
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
        if (gameOverScript != null)
        {
            Debug.Log("Player has won the game! Showing win screen.");
            winScreen.Show();
        }
        else
        {
            Debug.LogError("WinScreen not assigned!");
        }
        
    }
}
