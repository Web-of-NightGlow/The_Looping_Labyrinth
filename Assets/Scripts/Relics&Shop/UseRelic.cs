using UnityEngine;

public class UseRelic : MonoBehaviour
{
    public static void ApplyRelicEffect(ItemSO itemSO)
    {
        if(itemSO.maxHealth > 0)
            StatsManager.Instance.UpdateMaxHealth(itemSO.maxHealth);

        if(itemSO.speed > 0 )
            StatsManager.Instance.UpdateSpeed(itemSO.speed);

        if(itemSO.damage > 0)
            StatsManager.Instance.UpdateStrength(itemSO.damage);

        // if(itemSO.attackSpeed > 0)
        //     StatsManager.Instance.UpdateAttackSpeed(itemSO.attackSpeed);
    }
}
