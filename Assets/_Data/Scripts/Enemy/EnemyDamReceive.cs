using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamReceive : DamageReceiver
{
    [Header("Enemy Dam Receive")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected CapsuleCollider2D collide;
    [SerializeField] protected float enemyHurtTime = 0.5f;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
        this.LoadCollide();
    }
    protected void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected void LoadCollide()
    {
        if (this.collide != null) return;
        this.collide = GetComponent<CapsuleCollider2D>();
        Debug.Log(transform.name + ": LoadCollide", gameObject);
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }
    protected override void Reborn()
    {
        this.hurtTime = this.enemyHurtTime;
        this.hpMax = this.enemyCtrl.EnemySO.hpMax;
        this.collide.enabled = true;
        this.SetPosDead();
        base.Reborn();
    }
    protected override void OnDead()
    {
        this.collide.enabled = false;
        this.enemyCtrl.Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        this.OnDeadDrop();
    }
    protected void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawn.Instance.Drop(this.enemyCtrl.EnemySO.dropList, dropPos, dropRot);
    }
    protected override void StopHurt()
    {
        base.StopHurt();
        this.SetPosDead();
    }
    protected override void Hurt()
    {
        this.enemyCtrl.Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    protected virtual void SetPosDead()
    {
        this.enemyCtrl.Rigid.constraints = RigidbodyConstraints2D.None;
        this.enemyCtrl.Rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    protected void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            this.enemyCtrl.EnemyMovement.SetNewDestination();
    }
}
