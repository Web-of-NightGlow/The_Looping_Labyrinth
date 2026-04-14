using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    public GameObject[] statsSlots;
    public CanvasGroup statsCanvas;

    private bool statsOpen = false;

    private void Start()
    {
        UpdateAllStats();
    }

    private void Update()
    {
        if(Input.GetButtonDown("ToggleStats"))
        {
            if (!statsOpen)
            {
                Time.timeScale = 0;
                UpdateAllStats();
                statsCanvas.alpha = 1;
                statsCanvas.blocksRaycasts = true;
                statsOpen = true;
            }
            else
            {
                Time.timeScale = 1;
                UpdateAllStats();
                statsCanvas.alpha = 0;
                statsCanvas.blocksRaycasts = false;
                statsOpen = false;
            }
        }
    }


    public void UpdateStrength()
    {
        statsSlots[0].GetComponentInChildren<TMP_Text>().text = "Strength: " + StatsManager.Instance.damage;
    }


    public void UpdateSpeed()
    {
        statsSlots[1].GetComponentInChildren<TMP_Text>().text = "Speed: " + StatsManager.Instance.moveSpeed;
    }


    // public void UpdateDexterity()
    // {
    //     statsSlots[3].GetComponentInChildren<TMP_Text>().text = "Dexterity: " + StatsManager.Instance.dexterity;
    // }


    public void UpdateHealth()
    {
        statsSlots[2].GetComponentInChildren<TMP_Text>().text = "Health: " + StatsManager.Instance.currentHealth + "/" + StatsManager.Instance.maxHealth;
    }


    public void UpdateAllStats()
    {
        UpdateStrength();
        UpdateSpeed();
        //UpdateDexterity();
        UpdateHealth();
    }
}
