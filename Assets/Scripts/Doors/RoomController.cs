using UnityEngine;
using System.Collections.Generic;

public class RoomController : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public Door[] doors;

    private bool roomActive = false;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Enemy"))
            {
                enemies.Add(child.gameObject);
            }
        }
    }

    public void ActivateRoom()
    {
        roomActive = true;
        CloseDoors();
    }

    public void EnemyDied(GameObject enemy)
    {
        enemies.Remove(enemy);

        if (enemies.Count == 0 && roomActive)
        {
            ActivateRoom();
        }
    }

    void CloseDoors()
    {
        foreach (Door door in doors)
        {
            door.CloseDoor();
        }
    }

    void OpenDoors()
    {
        foreach (Door door in doors)
        {
            door.OpenDoor();
        }
    }
}