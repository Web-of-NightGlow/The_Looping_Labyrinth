using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public RoomController room;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            room.ActivateRoom();
        }
    }
}