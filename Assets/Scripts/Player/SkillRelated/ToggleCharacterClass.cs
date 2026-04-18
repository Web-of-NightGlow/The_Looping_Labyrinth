using UnityEngine;

public class ToggleCharacterClass : MonoBehaviour
{
    public PlayerVisualController playerVisual;
    public Player_CastMagic wizard;
    public PlayerCombat paladin;
    //public Player_Rogue rogue;
    public StatsManager statsManager;


    private void Start()
    {
        ApplySelection();
    }


    void ApplySelection()
    {
        Debug.Log("Selection: " + PlayerSelection.Instance);
        Debug.Log("Wizard ref: " + wizard);
        Debug.Log("Paladin ref: " + paladin);
        Debug.Log("StatsManager: " + StatsManager.Instance);
        var selection = PlayerSelection.Instance;

        if (selection == null)
        {
            Debug.LogError("No PlayerSelection found!");
            return;
        }

        //CLASS LOGIC
        if (selection.selectedClass == "Wizard")
        {
            wizard.enabled = true;
            paladin.enabled = false;
            //rogue.enabled = false;
        }
        else if(selection.selectedClass == "Paladin")
        {
            wizard.enabled = false;
            paladin.enabled = true;
            //rogue.enabled = false;
        }
        else if(selection.selectedClass == "Rogue")
        {
            wizard.enabled = false;
            paladin.enabled = true;
            //rogue.enabled = true;
        }
        else
        {
            Debug.LogWarning("Unknown class selected: " + selection.selectedClass);
        }


        //RACE STATS
        if (selection.selectedRace == "Human")
        {
            StatsManager.Instance.UpdateMaxHealth(5);
        }
        else if (selection.selectedRace == "Goblin")
        {
            StatsManager.Instance.UpdateSpeed(5);
        }
        else if (selection.selectedRace == "Orc")
        {
            StatsManager.Instance.UpdateStrength(5);
        }
        else
        {
            Debug.LogWarning("Unknown race selected: " + selection.selectedRace);
        }


        if (playerVisual != null)
        {
            playerVisual.SetAppearance(selection.selectedRace, selection.selectedClass);
        }
        else
        {
            Debug.LogWarning("PlayerVisualController not assigned!");
        }
    }
}
