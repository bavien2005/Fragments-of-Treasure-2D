using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : AnimationAbtract
{
    [Header("Player Animation")]
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }
    protected void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
    protected override void SetAnimation()
    {
        base.SetAnimation();
        this.SetDirection();
        this.SetSwitchWeapon();
    }

    protected override void SetAnimWalk()
    {
        this.playerCtrl.Anim.SetFloat("velocity.x", this.playerCtrl.PlayerMovement.Horizontal);
        this.playerCtrl.Anim.SetFloat("velocity.y", this.playerCtrl.PlayerMovement.Vertical);
    }
    protected void SetSwitchWeapon()
    {
        this.playerCtrl.Anim.SetBool("SwitchWeapon", this.playerCtrl.PlayerMovement.SwitchWeapon);
    }
    protected void SetDirection()
    {
        this.playerCtrl.Anim.SetBool("Right", this.playerCtrl.PlayerFlipDirect.Right);
        this.playerCtrl.Anim.SetBool("Left", this.playerCtrl.PlayerFlipDirect.Left);
        this.playerCtrl.Anim.SetBool("Down", this.playerCtrl.PlayerFlipDirect.Down);
        this.playerCtrl.Anim.SetBool("Up", this.playerCtrl.PlayerFlipDirect.Up);
    }
    protected override void SetAnimAttack()
    {
        this.playerCtrl.Anim.SetBool("Attack", this.playerCtrl.PlayerAttack.Attack);
    }
    protected override void SetAnimShoot()
    {
        this.playerCtrl.Anim.SetBool("Shoot", this.playerCtrl.PlayerShooting.Shoot);
    }
    protected override void SetAnimHurt()
    {
        this.playerCtrl.Anim.SetBool("Hurt", this.playerCtrl.PlayerDamReceive.IsHurt);
    }
    protected override void SetAnimDead()
    {
        this.playerCtrl.Anim.SetBool("Dead", this.playerCtrl.PlayerDamReceive.IsDead);
    }
}
