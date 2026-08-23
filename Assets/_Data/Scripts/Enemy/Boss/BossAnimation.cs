using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : AnimationAbtract
{
    [Header("Boss Animation")]

    [SerializeField] protected BossCtrl bossCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossCtrl();
    }
    protected void LoadBossCtrl()
    {
        if (this.bossCtrl != null) return;
        this.bossCtrl = GetComponentInParent<BossCtrl>();
        Debug.Log(transform.name + ": LoadBossCtrl", gameObject);
    }
    protected override void SetAnimation()
    {
        base.SetAnimation();
        this.SetAnimAngry();
    }
    protected override void SetAnimWalk()
    {
        this.bossCtrl.Anim.SetBool("Moving", this.bossCtrl.BossAttackCtrl.isMoving);
    }
    protected void SetAnimAngry()
    {
        this.bossCtrl.Anim.SetBool("Angry", this.bossCtrl.BossAttackCtrl.angry);
    }
    protected override void SetAnimAttack()
    {
        this.bossCtrl.Anim.SetBool("Attack1", this.bossCtrl.BossAttackCtrl.BossAttack1.Attack1);
        this.bossCtrl.Anim.SetBool("Attack2", this.bossCtrl.BossAttackCtrl.BossAttack2.Attack2);
        this.bossCtrl.Anim.SetBool("Attack3", this.bossCtrl.BossAttackCtrl.BossAttack3.Attack3);
    }
    protected override void SetAnimHurt()
    {

    }
    protected override void SetAnimDead()
    {
        this.bossCtrl.Anim.SetBool("Dead", this.bossCtrl.BossDamReceive.IsDead);
    }
}
