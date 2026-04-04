using UnityEngine;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class ShopKeeper : MonoBehaviour
{
    public Animator animator;
    public CanvasGroup shopCanvasGroup;
    public ShopManager shopManager;
    public static ShopKeeper currentShopKeeper;

    [SerializeField] private List<ShopRelics> shopHealth;
    [SerializeField] private List<ShopRelics> shopSpeed;
    [SerializeField] private List<ShopRelics> shopDamage;
    [SerializeField] private List<ShopRelics> shopDexterity;
    [SerializeField] private Camera shopKeeperCam;
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 0, -1);

    private bool playerInRange;
    private bool isShopOpen;


    void Update()
    {
        if(playerInRange && Input.GetButtonDown("Interact"))
        {
            if (!isShopOpen)
            {
                currentShopKeeper = this;
                Time.timeScale = 0;
                shopCanvasGroup.alpha = 1f;
                shopCanvasGroup.interactable = true;
                shopCanvasGroup.blocksRaycasts = true;
                isShopOpen = true;

                shopKeeperCam.transform.position = transform.position + cameraOffset;
                shopKeeperCam.gameObject.SetActive(true);
                OpenHealthShop();
            }
            else
            {
                currentShopKeeper = null;
                Time.timeScale = 1;
                shopCanvasGroup.alpha = 0f;
                shopCanvasGroup.interactable = false;
                shopCanvasGroup.blocksRaycasts = false;
                isShopOpen = false;
                shopKeeperCam.gameObject.SetActive(false);
            }
        }
    }


    public void OpenHealthShop()
    {
        shopManager.PopulateShopItems(shopHealth);
    }


    public void OpenSpeedShop()
    {
        shopManager.PopulateShopItems(shopSpeed);
    }


    public void OpenDamageShop()
    {
        shopManager.PopulateShopItems(shopDamage);
    }

    
    public void OpenDexterityShop()
    {
        shopManager.PopulateShopItems(shopDexterity);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            animator.SetBool("playerInRange", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            animator.SetBool("playerInRange", false);
        }
    }

}
