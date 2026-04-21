using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public static WinScreen Instance;
    public CanvasGroup canvasGroup;

    void Awake()
    {
        Debug.Log($"WinScreen Awake: {gameObject.GetInstanceID()}");

        if (Instance != null && Instance != this)
        {
            Debug.Log($"Destroying duplicate WinScreen: {gameObject.GetInstanceID()} (keeping {Instance.gameObject.GetInstanceID()})");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        Hide(); // start hidden properly
    }


    public void Show()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        Time.timeScale = 0;
    }


    public void Hide()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        Time.timeScale = 1;
    }


    public void MainMenu()
    {
        Hide();
        SceneManager.LoadScene("MainMenu");
    }


    public void CharacterSelect()
    {
        Hide();
        SceneManager.LoadScene("CharacterSelection");
    }

    void OnDestroy()
    {
        Debug.Log($"WinScreen DESTROYED: {gameObject.GetInstanceID()} frame {Time.frameCount}");
    }
}