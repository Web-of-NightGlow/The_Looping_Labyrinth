using UnityEngine;

public class Door : MonoBehaviour
{
    public SpriteRenderer sr;
    public Collider2D col;

    public Sprite openSprite;
    public Sprite closedSprite;

    public void OpenDoor()
    {
        Debug.Log("Opening door");
        sr.sprite = openSprite;
        col.enabled = false;
    }

    public void CloseDoor()
    {
        Debug.Log("Closing door");
        sr.sprite = closedSprite;
        col.enabled = true;
    }
}