using UnityEngine;
using TMPro;
using System.Reflection;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    public ItemSO itemSO;
    public TMP_Text relicNameText;
    public TMP_Text priceText;
    public Image relicImage;

    [SerializeField] private ShopManager shopManager;
    [SerializeField] private ShopInfo shopInfo;

    private int price;

    public void Initialize(ItemSO newItemSO, int price)
    {
        itemSO = newItemSO;
        relicNameText.text = itemSO.itemName;
        relicImage.sprite = itemSO.itemIcon;
        relicNameText.text = itemSO.itemName;
        this.price = price;
        priceText.text = price.ToString();

    }


    public void OnBuyButtonClicked()
    {
        shopManager.TryBuyItem(itemSO, price);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if(itemSO != null)
        {
            shopInfo.ShowRelicInfo(itemSO);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        shopInfo.HideRelicInfo();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if(itemSO != null)
        {
            shopInfo.FollowMouse();
        }
    }
}
