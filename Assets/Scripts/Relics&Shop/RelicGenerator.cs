using UnityEngine;
using System.Collections.Generic;

public class RelicGenerator : MonoBehaviour
{
    public List<ItemSO> relicPool;   // Assign all relics in inspector
    public GameObject relicPrefab;  // Your Relic prefab

    void Start()
    {
        SpawnRandomRelic();
    }


    public void SpawnRandomRelic()
    {
        ItemSO selectedRelic = GetWeightedRandomRelic();

        GameObject relicObj = Instantiate(relicPrefab, transform.position, Quaternion.identity);
        Relic relicComponent = relicObj.GetComponent<Relic>();

        relicComponent.relicData = selectedRelic;
        relicComponent.quantity = 1;
    }


    ItemSO GetWeightedRandomRelic()
    {
        float totalWeight = 0f;

        // Calculate total weight
        foreach (ItemSO relic in relicPool)
        {
            float weight = 1f / Mathf.Max(relic.cost, 1); // avoid divide by 0
            totalWeight += weight;
        }

        float randomPoint = Random.Range(0, totalWeight);

        // Pick relic
        float currentWeight = 0f;
        foreach (ItemSO relic in relicPool)
        {
            float weight = 1f / Mathf.Max(relic.cost, 1);
            currentWeight += weight;

            if (randomPoint <= currentWeight)
            {
                return relic;
            }
        }

        // fallback (should never hit)
        return relicPool[0];
    }
}