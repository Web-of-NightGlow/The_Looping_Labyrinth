using UnityEngine;

public class PlayerInitilizer : MonoBehaviour
{
    public Player_CastMagic wizard;
    public PlayerCombat paladin;
    public Player_Rogue rogue;
    public PlayerVisualController playerVisual;

    void Start()
    {
        var selection = PlayerSelection.Instance;

        if (selection == null)
        {
            Debug.LogError("No PlayerSelection found!");
            return;
        }

        ApplyClass(selection);
        ApplyStats(selection);

        if (playerVisual != null)
        {
            playerVisual.SetAppearance(selection.selectedRace, selection.selectedClass);
        }
        else
        {
            Debug.LogWarning("PlayerVisualController not assigned!");
        }
    }

    void ApplyClass(PlayerSelection selection)
    {
        wizard.enabled = selection.selectedClass == "Wizard";
        paladin.enabled = selection.selectedClass == "Paladin";
        rogue.enabled = selection.selectedClass == "Rogue";
    }

    void ApplyStats(PlayerSelection selection)
    {
        // Prevent double applying
        if (selection.hasAppliedStats) return;

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

        selection.hasAppliedStats = true;
    }
}