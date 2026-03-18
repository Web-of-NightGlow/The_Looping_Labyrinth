using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] relicSlots;
    public int gold;
    public TMP_Text goldText;


    private void Start()
    {
        foreach (var slot in relicSlots)
        {
            slot.UpdateUI();
        }
    }

    private void OnEnable()
    {
        Relic.OnRelicLooted += AddToInventory;
    }

    private void OnDisable()
    {
        Relic.OnRelicLooted -= AddToInventory;
    }

    public void AddToInventory(ItemSO itemSO, int quantity)
    {
        if(itemSO.isGold)
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
                    slot.itemData = itemSO;
                    slot.quantity = quantity;
                    slot.UpdateUI();
                    UseRelicFromSlot(slot);
                    return;
                }
            }
        }
    }

    public void UseRelicFromSlot(InventorySlot slot)
{
    if (slot.itemData != null && slot.quantity > 0)
    {
        UseRelic.ApplyRelicEffect(slot.itemData);
        if (slot.quantity <= 0)
        {
            slot.itemData = null;
        }
        slot.UpdateUI();
    }
}
}
