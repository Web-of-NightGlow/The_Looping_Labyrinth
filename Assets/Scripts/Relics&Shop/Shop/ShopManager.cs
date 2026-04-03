using System.Runtime.Serialization;
using UnityEngine;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<ShopRelics> shopRelics;
    [SerializeField] private ShopSlot[] shopSlots;
    [SerializeField] private InventoryManager inventoryManager;

    //temp
    private void Start()
    {
        PopulateShopItems();
    }

    public void PopulateShopItems()
    {
        for (int i = 0; i < shopRelics.Count && i < shopSlots.Length; i++)
        {
            ShopRelics shopRelic = shopRelics[i];   
            shopSlots[i].Initialize(shopRelic.itemSO, shopRelic.price);
            shopSlots[i].gameObject.SetActive(true);     
        }

        for (int i = shopRelics.Count; i < shopSlots.Length; i++)
        {
            shopSlots[i].gameObject.SetActive(false);
        }
    }

    public void TryBuyItem(ItemSO itemSO, int price)
    {
        if (itemSO != null && inventoryManager.gold >= price)
        {
            inventoryManager.gold -= price;
            inventoryManager.goldText.text = inventoryManager.gold.ToString();
            //inventoryManager.AddItem(itemSO, 1);
        }
    }
}

[System.Serializable]
public class ShopRelics
{
    public ItemSO itemSO;
    public int price;
}