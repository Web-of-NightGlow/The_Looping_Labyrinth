using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public static GameOverScript Instance;

     void Awake()
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

    public void SetUp()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }


    public void RestartGame()
    {
        ResetGame();
        Time.timeScale = 1;
        SceneManager.LoadScene("CharacterSelection");
        gameObject.SetActive(false);
    }


    public void ExitGame()
    {
        ResetGame();
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        gameObject.SetActive(false);
    }


    public void ResetGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartNewGame();
        }

        // Destroy persistent player if somehow exists
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Destroy(player);
        }
    }

    void OnDestroy()
    {
        Debug.Log(gameObject.name + " UI element destroyed!");
    }
}
