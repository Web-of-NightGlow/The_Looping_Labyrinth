using UnityEngine;

public class Relic : MonoBehaviour
{
    public ItemSO relicData;
    public SpriteRenderer sr;
    public Animator anim;

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
            Destroy(gameObject, 0.5f);
        }
    }
}
