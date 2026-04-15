using UnityEngine;
using System.Collections.Generic;

public class RoomController : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public Door[] doors;

    private bool roomActive = false;

    private void Start()
    {
        enemies.Clear();

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
        if (roomActive) return;

        roomActive = true;
        CloseDoors();
    }

    public void EnemyDied(GameObject enemy)
    {
        enemies.Remove(enemy);
        Debug.Log("Enemies left: " + enemies.Count);

        if (enemies.Count == 0 && roomActive)
        {
            OpenDoors();
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