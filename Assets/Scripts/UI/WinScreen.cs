using UnityEngine;
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
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void CharacterSelect()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("CharacterSelection");
    }
}