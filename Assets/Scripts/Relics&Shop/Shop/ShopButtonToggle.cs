using UnityEngine;

public class ShopButtonToggle : MonoBehaviour
{
    public void OpenHealthShop()
    {
        if (ShopKeeper.currentShopKeeper != null)
        {
            ShopKeeper.currentShopKeeper.OpenHealthShop();
        }
    }


    public void OpenSpeedShop()
    {
        if (ShopKeeper.currentShopKeeper != null)
        {
            ShopKeeper.currentShopKeeper.OpenSpeedShop();
        }
    }


    public void OpenDamageShop()
    {
        if (ShopKeeper.currentShopKeeper != null)
        {
            ShopKeeper.currentShopKeeper.OpenDamageShop();
        }
    }


    // public void OpenDexterityShop()
    // {
    //     if (ShopKeeper.currentShopKeeper != null)
    //     {
    //         ShopKeeper.currentShopKeeper.OpenDexterityShop();
    //     }
    // }
}
