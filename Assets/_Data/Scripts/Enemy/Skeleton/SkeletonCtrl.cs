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
        Debug.Log(transform.name + ":LoadAnimator", gameObject);
    }
    protected void LoadSkeletonAttack()
    {
        if (this.skeletonAttack != null) return;
        this.skeletonAttack = GetComponentInChildren<SkeletonAttack>();
        Debug.Log(transform.name + ":LoadSkeletonAttack", gameObject);
    }
}
