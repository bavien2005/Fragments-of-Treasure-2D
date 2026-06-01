using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAnimation : AnimationAbtract
{
    [Header("Orc Animation")]
    [SerializeField] protected OrcCtrl orcCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadOrcCtrl();
    }
    protected void LoadOrcCtrl()
    {
        if (this.orcCtrl != null) return;
        this.orcCtrl = GetComponentInParent<OrcCtrl>();
        Debug.Log(transform.name + ": LoadOrcCtrl", gameObject);
    }
    protected override void SetAnimWalk()
    {
        this.orcCtrl.Anim.SetBool("Moving", this.orcCtrl.EnemyMovement.IsMoving);
    }
    protected override void SetAnimAttack()
    {
        this.orcCtrl.Anim.SetBool("Attack", this.orcCtrl.OrcAttack.IsAttack);
    }
    protected override void SetAnimHurt()
    {
        this.orcCtrl.Anim.SetBool("Hurt", this.orcCtrl.EnemyDamReceive.IsHurt);
    }
    protected override void SetAnimDead()
    {
        this.orcCtrl.Anim.SetBool("Dead", this.orcCtrl.EnemyDamReceive.IsDead);
    }
}
