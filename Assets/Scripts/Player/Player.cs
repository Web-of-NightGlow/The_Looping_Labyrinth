using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterDataBase characterDB;
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


    private void Load()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        UpdateCharacter(selectedCharacter);
    }


    private void UpdateCharacter(int selectedCharacter)
    {
        Character character = characterDB.GetCharacter(selectedCharacter);
        artSprite.sprite = character.characterSprite;
    }
}
