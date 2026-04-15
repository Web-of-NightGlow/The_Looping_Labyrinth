using UnityEngine;

public class OneWayDoor : MonoBehaviour
{
    public SpriteRenderer sr;

    public Collider2D triggerCol;   // trigger
    public Collider2D blockCol;     // wall

    public Sprite openSprite;
    public Sprite closedSprite;

    private bool hasClosed = false;

    private void Start()
    {
        OpenDoor();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (hasClosed) return;

        if (collision.CompareTag("Player"))
        {
            CloseDoor();
            hasClosed = true;
        }
    }

    public void OpenDoor()
    {
        sr.sprite = openSprite;
        blockCol.enabled = false;
    }

    public void CloseDoor()
    {
        sr.sprite = closedSprite;
        blockCol.enabled = true;
    }
}