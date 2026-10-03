using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamReceive : DamageReceiver
{
    [Header("Player Dam Receive")]
    [SerializeField] protected int playerHpMax = 10;
    [SerializeField] protected float playerHurtTime = 0.5f;
    [SerializeField] protected string hitSoundName = "SwordBlood";
    [SerializeField, Range(0f, 1f)] protected float hitSoundVolume = 0.8f;
    [SerializeField] protected float meteorStunTime = 0.55f;
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
    }
    protected void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
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

    public override void Deduct(int damage)
    {
        int previousHp = this.hp;
        base.Deduct(damage);
        if (this.hp >= previousHp) return;

        if (AudioManagerr.Instance != null)
            AudioManagerr.Instance.PlaySFX(this.hitSoundName, this.hitSoundVolume);
    }

    /// <summary>
    /// Reuses the player's existing Hurt animation/state when a falling rock
    /// actually hits them. IsHurt blocks movement, attacks and shooting, so it
    /// also provides a brief, readable stun and prevents meteor hit spam.
    /// </summary>
    public bool ReceiveMeteorHit(int damage)
    {
        if (this.isDead || this.isHurt) return false;

        this.hurtTime = this.meteorStunTime;
        this.hurtTimeCounter = 0f;
        this.Deduct(damage);

        return true;
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
