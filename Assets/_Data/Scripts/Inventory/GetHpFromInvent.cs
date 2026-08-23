using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHpFromInvent : GetItemFromInvent
{
    [Header("GetHpFromInvent")]
    [SerializeField] protected HpPotionSO hpPotionSO;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHpPotionSO();
    }
    protected void LoadHpPotionSO()
    {
        if (this.hpPotionSO != null) return;
        this.hpPotionSO = Resources.Load<HpPotionSO>("GameData/HpPotionSO");
        Debug.Log(transform.name + ": LoadHpPotionSO", gameObject);
    }
    protected override void GetItemInventory()
    {
        foreach (ItemInventory item in this.inventory.Items)
        {
            if (item.itemProfile.itemCode != ItemCode.Heath || item.itemCount <= 0) continue;
            item.itemCount--;
            this.hpPotionSO.hpPotionCount += 1;
        }
    }
}
