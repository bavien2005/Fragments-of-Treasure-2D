using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAttack : EnemyAttack
{
    [Header("Orc Attack")]
    [SerializeField] protected Transform enemyDamSender;
    [SerializeField] protected float orcDisAttackLimit = 2f;
    [SerializeField] protected float orcAttackTime = 0.5f;
    [SerializeField] protected float orcAttackCoolDown = 2f;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.disAttackLimit = this.orcDisAttackLimit;
        this.attackTime = this.orcAttackTime;
        this.attackCoolDown = this.orcAttackCoolDown;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyDamSender();
    }
    protected void LoadEnemyDamSender()
    {
        if (this.enemyDamSender != null) return;
        this.enemyDamSender = transform.parent.Find("EnemyDamSender");
        Debug.Log(transform.name + ": LoadEnemyDamSender", gameObject);
    }
    protected override void Attack()
    {
        this.enemyDamSender.gameObject.SetActive(true);
        AudioManagerr.Instance.PlaySFX("EnemyAttack");
        base.Attack();
    }
    protected override void StopAttack()
    {
        if (this.attackTimeCounter <= 0f && this.isAttack)
        {
            this.isAttack = false;
            this.enemyDamSender.gameObject.SetActive(false);
        }
    }
}
