using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class ItemPickupable : DinoBehaviourScript
{
    [SerializeField] protected ItemCtrl itemCtrl;
    [SerializeField] protected CircleCollider2D collide;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemCtrl();
        this.LoadCollider();
    }
    protected void LoadItemCtrl()
    {
        if (this.itemCtrl != null) return;
        this.itemCtrl = GetComponentInParent<ItemCtrl>();
        Debug.Log(transform.name + ": LoadItemCtrl", gameObject);
    }
    protected void LoadCollider()
    {
        if (this.collide != null) return;
        this.collide = GetComponent<CircleCollider2D>();
        this.collide.isTrigger = true;
        this.collide.radius = 0.3f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    protected static ItemCode String2ItemCode(string itemName)
    {
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
    }
    public ItemCode GetItemCode()
    {
        return ItemPickupable.String2ItemCode(transform.parent.name);
    }
    public void Picked()
    {
        this.itemCtrl.ItemDespawn.DespawnObj();
    }
}
