using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class ItemLooter : DinoBehaviourScript
{
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected CircleCollider2D collide;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
        this.LoadCollider();
    }
    protected void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GetComponentInParent<Inventory>();
        Debug.Log(transform.name + ": LoadInventory", gameObject);
    }
    protected void LoadCollider()
    {
        if (this.collide != null) return;
        this.collide = GetComponent<CircleCollider2D>();
        this.collide.isTrigger = true;
        this.collide.radius = 0.5f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        ItemPickupable itemPickupable = other.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;
        ItemCode itemCode = itemPickupable.GetItemCode();
        if (this.inventory.PickupItem(itemCode, 1))
        {
            itemPickupable.Picked();
            AudioManagerr.Instance.PlaySFX("Pickup");
        }
    }
}
