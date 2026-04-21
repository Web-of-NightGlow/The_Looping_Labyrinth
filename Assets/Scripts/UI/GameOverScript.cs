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
    }


    public void RestartGame()
    {
        ResetGame();
        SceneManager.LoadScene("CharacterSelection");
        gameObject.SetActive(false);
    }


    public void ExitGame()
    {
        ResetGame();
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
