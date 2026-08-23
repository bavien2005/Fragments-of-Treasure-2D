using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : DinoBehaviourScript
{
    [SerializeField] protected Transform target;
    [SerializeField] protected BossAttack bossAttack;
    [SerializeField] protected float distance;
    [SerializeField] protected float distanceToTarget;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTarget();
        this.LoadBossAttack();
    }
    protected void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("Player").transform;
        Debug.Log(transform.name + ": LoadTarget", gameObject);
    }
    protected void LoadBossAttack()
    {
        if (this.bossAttack != null) return;
        this.bossAttack = transform.parent.GetComponentInChildren<BossAttack>();
        Debug.Log(transform.name + ": LoadBossAttack", gameObject);
    }
    protected void Update()
    {
        this.Move();
    }
    public bool CanMove()
    {
        this.distance = Vector2.Distance(transform.parent.position, target.position);
        if (this.distance <= this.distanceToTarget) return true;
        return false;
    }
    protected void Move()
    {
        if (!this.CanMove()) return;
        this.bossAttack.enabled = true;
    }
}
