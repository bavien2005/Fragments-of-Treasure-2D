using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamReceive : DamageReceiver
{
    [Header("Player Dam Receive")]
    [SerializeField] protected int playerHpMax = 10;
    [SerializeField] protected float playerHurtTime = 0.5f;
    [SerializeField] protected CapsuleCollider2D collide;
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected PlayerHpSO playerHpSO;
    protected override void Start()
    {
        base.Start();
        this.hp = this.playerHpSO.currentHp;
        this.playerHpMax = this.playerHpSO.maxHp;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadPlayerCtrl();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }
    protected void LoadCollider()
    {
        if (this.collide != null) return;
        this.collide = GetComponent<CapsuleCollider2D>();
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    protected void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
    protected override void Reborn()
    {
        this.hpMax = this.playerHpSO.maxHp;
        this.hurtTime = this.playerHurtTime;
        this.hp = this.playerHpSO.currentHp;
        this.playerHpMax = this.playerHpSO.maxHp;
    }
    protected override void OnDead()
    {
        this.StopMovement();
        AudioManagerr.Instance.ClockMusic();
        RestartToggle.Instance.RestartGameMenu();
    }
    protected void StopMovement()
    {
        this.collide.enabled = false;
        Vector3 posDead = transform.parent.position;
        posDead.z = 1;
        transform.parent.position = posDead;
        this.playerCtrl.PlayerMovement._Rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
