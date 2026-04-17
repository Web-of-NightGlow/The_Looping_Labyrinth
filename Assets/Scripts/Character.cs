using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/Character")]
[System.Serializable]
public class Character : ScriptableObject
{
    public string characterName;
    public string characterBonus;
    public Sprite characterSprite;
}
