using UnityEngine;

[System.Serializable]
public class Character
{
    public string characterName;
    public string characterBonus;
    public Sprite characterSprite;

    public bool isWizard;
    public bool isPaladin;
    public bool isRogue;

    public int bonusHealth;
    public int bonusSpeed;
    public int bonusDamage;
}
