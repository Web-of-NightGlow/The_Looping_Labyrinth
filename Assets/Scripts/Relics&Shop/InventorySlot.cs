using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public ItemSO itemData;
    public int quantity;

    public Image itemImage;
    public TMP_Text quantityText;

    public void UpdateUI()
    {
        if(itemData != null)
        {
            itemImage.sprite = itemData.itemIcon;
            itemImage.gameObject.SetActive(true);
            quantityText.text = quantity.ToString();
        }
        else
        {
            itemImage.gameObject.SetActive(false);
            quantityText.text = "";
        }
    }
}
