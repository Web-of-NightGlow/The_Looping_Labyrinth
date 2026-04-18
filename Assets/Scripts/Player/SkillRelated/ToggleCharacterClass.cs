using UnityEngine;

public class ToggleCharacterClass : MonoBehaviour
{
    
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
    }
}
