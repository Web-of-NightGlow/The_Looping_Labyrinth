using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    public void EnterPlayerSelection()
    {
        SceneManager.LoadSceneAsync("CharacterSelection");
    }

    
    public void QuitGame()
    {
        Application.Quit();
    }
}
