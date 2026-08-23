using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcCtrl : EnemyCtrl
{
    [Header("Orc Ctrl")]
    [SerializeField] protected Animator anim;
    [SerializeField] protected OrcAttack orcAttack;
    public Animator Anim => anim;
    public OrcAttack OrcAttack => orcAttack;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimator();
        this.LoadOrcAttack();
    }
    protected void LoadAnimator()
    {
        if (this.anim != null) return;
        this.anim = GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ":LoadAnimator", gameObject);
    }
    protected void LoadOrcAttack()
    {
        if (this.orcAttack != null) return;
        this.orcAttack = GetComponentInChildren<OrcAttack>();
        Debug.Log(transform.name + ":LoadOrcAttack", gameObject);
    }
}
