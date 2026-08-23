using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GetItemFromInvent : DinoBehaviourScript
{
    [Header("GetItemFromInvent")]
    [SerializeField] protected Inventory inventory;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
    }

    protected void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GetComponent<Inventory>();
        Debug.Log(transform.name + ": LoadInventory");
    }

    protected void Update()
    {
        this.GetItemInventory();
        this.inventory.ClearEmptyItem();
    }

    protected abstract void GetItemInventory();
    
}
 