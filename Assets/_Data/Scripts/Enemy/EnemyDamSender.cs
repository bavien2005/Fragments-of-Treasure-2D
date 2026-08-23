using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamSender : DamageSender
{
    [Header("Enemy DamSender")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected PolygonCollider2D collide;
    public PolygonCollider2D Collide => collide;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
        this.LoadCollider();
    }
    protected void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected void LoadCollider()
    {
        if (this.collide != null) return;
        this.collide = GetComponent<PolygonCollider2D>();
        this.collide.isTrigger = true;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (this.enemyCtrl.EnemyDamReceive.IsDeaded()) return;
        if (other.gameObject.CompareTag("Enemy")) return;
        base.OnTriggerEnter2D(other);
    }
}
