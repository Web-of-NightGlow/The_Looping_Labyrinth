using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Persistant Objects")]
    public GameObject[] persistantObjects;

    private void Awake()
    {
        if(Instance != null)
        {
            CleanUpAndDestroy();
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            MarkPersistantObjects();
        }
    }


    private void MarkPersistantObjects()
    {
        foreach (GameObject obj in persistantObjects)
        {
            if(obj != null)
            {
                DontDestroyOnLoad(obj);
            }
        }
    }


    private void CleanUpAndDestroy()
    {
        foreach (GameObject obj in persistantObjects)
        {
            if(obj != null)
            {
                Destroy(obj);
            }
        }
        Destroy(gameObject);
    }
}
