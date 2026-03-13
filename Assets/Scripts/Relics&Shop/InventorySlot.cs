using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemSO itemData;
    public Image itemImage;

    public void UpdateUI()
    {
        if(itemData != null)
        {
            itemImage.sprite = itemData.icon;
            itemImage.gameObject.SetActive(true);
        }
        else
        {
            itemImage.gameObject.SetActive(false);
        }
    }
}
