using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public static WinScreen Instance;

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

    public void Show()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Win screen activated and game paused.");
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
}