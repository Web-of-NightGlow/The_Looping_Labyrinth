using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public int gold;
    public TMP_Text goldText;

    private void OnEnable()
    {
        Relic.OnRelicLooted += AddToInventory;
    }

    private void OnDisable()
    {
        Relic.OnRelicLooted -= AddToInventory;
    }

    public void AddToInventory(ItemSO item, int quantity)
    {
        if(item.isGold)
        {
            gold += 1;
            goldText.text = gold.ToString();
            return;
        }
        else
        {
            UpdateUI();
        }
    }
}
