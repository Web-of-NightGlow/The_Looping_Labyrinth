using UnityEngine;
using System.Collections.Generic;

public class PlayerVisualController : MonoBehaviour
{
    public Animator animator;

    [System.Serializable]
    public class CharacterSet
    {
        public string race;
        public string characterClass;
        public AnimatorOverrideController overrideController;
    }

    public List<CharacterSet> characterSets;

    private AnimatorOverrideController runtimeOverride;

    public void SetAppearance(string race, string characterClass)
    {
        CharacterSet match = characterSets.Find(c =>
            c.race == race && c.characterClass == characterClass);

        if (match == null)
        {
            Debug.LogError($"No character set found for {race} {characterClass}");
            return;
        }

        animator.runtimeAnimatorController = match.overrideController;

        Debug.Log($"Applied visuals: {race} {characterClass}");
    }
}