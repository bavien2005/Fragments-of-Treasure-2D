using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : EnemyAbstract
{
    [Header("Enemy Follow")]
    [SerializeField] protected Transform target;
    public Transform Target => target;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTarget();
    }
    protected void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("Player").transform;
        Debug.Log(transform.name + ": LoadTarget", gameObject);
    }
    protected void Update()
    {
        this.Following();
    }
    protected void Following()
    {
        if (this.enemyCtrl.EnemyDamReceive.IsDead) return;
        if (this.enemyCtrl.EnemyDamReceive.IsHurt) return;
        if (!this.enemyCtrl.EnemyDetect.Detect) return;
        this.enemyCtrl.Rigid.MovePosition(Vector2.MoveTowards
        (transform.parent.position, this.target.position, this.enemyCtrl.EnemyMovement.Speed * Time.fixedDeltaTime));
    }
}
