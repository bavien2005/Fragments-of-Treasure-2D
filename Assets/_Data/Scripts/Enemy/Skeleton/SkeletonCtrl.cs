using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCtrl : EnemyCtrl
{
    [Header("Skeleton Ctrl")]
    [SerializeField] protected Animator anim;
    [SerializeField] protected SkeletonAttack skeletonAttack;
    public Animator Anim => anim;
    public SkeletonAttack SkeletonAttack => skeletonAttack;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimator();
        this.LoadSkeletonAttack();
    }
    protected void LoadAnimator()
    {
        if (this.anim != null) return;
        this.anim = GetComponentInChildren<Animator>();
    }
    protected void LoadSkeletonAttack()
    {
        if (this.skeletonAttack != null) return;
        this.skeletonAttack = GetComponentInChildren<SkeletonAttack>();
    }
}
