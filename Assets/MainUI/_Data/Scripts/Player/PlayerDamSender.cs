using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamSender : DamageSender
{
    [Header("Player DamSender")]
    [SerializeField] protected PolygonCollider2D collide;
    public PolygonCollider2D Collide => collide;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
    }
    protected void LoadCollider()
    {
        if (this.collide != null) return;
        this.collide = GetComponent<PolygonCollider2D>();
        this.collide.isTrigger = true;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
}
