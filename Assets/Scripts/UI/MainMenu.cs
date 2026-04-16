using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void EnterPlayerSelection()
    {
        SceneManager.LoadSceneAsync("CharacterSelection");
    }
}
