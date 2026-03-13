using UnityEngine;
using System;

public class Relic : MonoBehaviour
{
    public ItemSO relicData;
    public SpriteRenderer sr;
    public Animator anim;

    public static event Action<ItemSO, int> OnRelicLooted;

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
            OnRelicLooted?.Invoke(relicData, 1);
            Destroy(gameObject, 0.5f);
        }
    }
}
