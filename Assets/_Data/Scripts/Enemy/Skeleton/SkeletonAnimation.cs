using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimation : AnimationAbtract
{
    [Header("Skeleton Animation")]
    [SerializeField] protected SkeletonCtrl skeletonCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSkeletonCtrl();
    }
    protected void LoadSkeletonCtrl()
    {
        if (this.skeletonCtrl != null) return;
        this.skeletonCtrl = GetComponentInParent<SkeletonCtrl>();
        Debug.Log(transform.name + ": LoadSkeletonCtrl", gameObject);
    }
    protected override void SetAnimWalk()
    {
        this.skeletonCtrl.Anim.SetBool("Moving", this.skeletonCtrl.EnemyMovement.IsMoving);
    }
    protected override void SetAnimAttack()
    {
        this.skeletonCtrl.Anim.SetBool("Attack", this.skeletonCtrl.SkeletonAttack.IsAttack);
    }
    protected override void SetAnimHurt()
    {
        this.skeletonCtrl.Anim.SetBool("Hurt", this.skeletonCtrl.EnemyDamReceive.IsHurt);
    }
    protected override void SetAnimDead()
    {
        this.skeletonCtrl.Anim.SetBool("Dead", this.skeletonCtrl.EnemyDamReceive.IsDead);
    }
}
