using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public CharacterDataBase characterDB;
    public TMP_Text nameText;
    public TMP_Text bonusText;
    public SpriteRenderer artSprite;

    private int selectedCharacter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!PlayerPrefs.HasKey("SelectedCharacter"))
        {
            selectedCharacter = 0;
        }
        else
        {
            Load();
        }

        UpdateCharacter(selectedCharacter);
    }


    public void NextCharacter()
    {
        selectedCharacter++;
        if (selectedCharacter >= characterDB.CharacterCount)
        {
            selectedCharacter = 0;
        }
        UpdateCharacter(selectedCharacter);
        Save();
    }  


    public void PreviousCharacter()
    {
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter = characterDB.CharacterCount - 1;
        }
        UpdateCharacter(selectedCharacter);
        Save();
    }


    private void UpdateCharacter(int selectedCharacter)
    {
        Character character = characterDB.GetCharacter(selectedCharacter);
        nameText.text = character.characterName;
        bonusText.text = character.characterBonus;
        artSprite.sprite = character.characterSprite;
    }


    private void Load()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        UpdateCharacter(selectedCharacter);
    }


    private void Save()
    {
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
    }


    public void ChangeScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
