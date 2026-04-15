using UnityEngine;

public class Door : MonoBehaviour
{
    public SpriteRenderer sr;
    public Collider2D col;

    public Sprite openSprite;
    public Sprite closedSprite;

    public void OpenDoor()
    {
        sr.sprite = openSprite;
        col.enabled = false;
    }

    public void CloseDoor()
    {
        sr.sprite = closedSprite;
        col.enabled = true;
    }
}