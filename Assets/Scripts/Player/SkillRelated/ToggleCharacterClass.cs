using UnityEngine;

public class ToggleCharacterClass : MonoBehaviour
{
    public PlayerCombat playerCombat;
    public Player_CastMagic playerCastMagic;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("ToggleCharacterClass"))
        {
            playerCombat.enabled = !playerCombat.enabled;
            playerCastMagic.enabled = !playerCastMagic.enabled;
        }
    }
}
