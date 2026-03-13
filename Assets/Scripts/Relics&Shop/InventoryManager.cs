using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] relicSlots;
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
            gold += quantity;
            goldText.text = gold.ToString();
            return;
        }
        else
        {
            foreach (var slot in relicSlots)
            {
                if (slot.itemData == null)
                {
                    slot.itemData = item;
                    slot.quantity = quantity;
                    slot.UpdateUI();
                    return;
                }
            }
        }
    }
}
