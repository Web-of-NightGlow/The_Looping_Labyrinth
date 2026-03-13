using UnityEngine;

public class PlayerSwitchCharacterClass : MonoBehaviour
{
    public PlayerCombat combatScript;
    public Player_CastMagic magicScript;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ToggleCharacterClass"))
        {
            combatScript.enabled = !combatScript.enabled;
            magicScript.enabled = !magicScript.enabled;
        }
    }
}
