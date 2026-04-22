using UnityEngine;
using System;

public class Relic : MonoBehaviour
{
    public ItemSO relicData;
    public SpriteRenderer sr;
    public Animator anim;
    AudioManager audioManager;
    
    public int quantity;

    public static event Action<ItemSO, int> OnRelicLooted;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    private void Start()
    {
        if (relicData != null)
        {
            sr.sprite = relicData.itemIcon;
            name = relicData.itemName;
        }
    }


    private void OnValidate()
    {
        if (relicData == null)
            return;
        sr.sprite = relicData.itemIcon;
        this.name = relicData.itemName;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.Play("relicPickUp");
            audioManager.PlaySFX(audioManager.relicPickupClip);
            OnRelicLooted?.Invoke(relicData, quantity);
            Destroy(gameObject, 0.5f);
        }
    }
}
