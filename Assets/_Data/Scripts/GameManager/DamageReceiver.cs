using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : DinoBehaviourScript
{
    [Header("Damage Receiver")]
    [SerializeField] protected int hp;
    [SerializeField] protected int hpMax = 10;
    [SerializeField] protected bool isHurt;
    [SerializeField] protected bool isDead;
    public float hurtTime = 1f;
    public float hurtTimeCounter = 0f;
    public int Hp => hp;
    public int HPMax => hpMax;
    public bool IsHurt => isHurt;
    public bool IsDead => isDead;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }
    protected override void Start()
    {
        base.Start();
        this.Reborn();
    }
    protected virtual void Update()
    {
        this.Hurting();
    }
    protected virtual void Reborn()
    {
        this.hp = hpMax;
        this.isDead = false;
    }
    public virtual void Add(int hp)
    {
        if (this.isDead) return;
        this.hp += hp;
        if (this.hp >= this.hpMax) this.hp = this.hpMax;
    }

    public virtual void Deduct(int damage)
    {
        if (this.isDead) return;
        this.hp -= damage;
        this.isHurt = true;
        if (this.hp <= 0) this.hp = 0;
        this.CheckIsDead();

    }
    public bool IsDeaded()
    {
        return this.hp <= 0;
    }
    protected void CheckIsDead()
    {
        if (!this.IsDeaded()) return;
        this.isDead = true;
        this.OnDead();
    }
    protected virtual void OnDead()
    {

    }
    protected void Hurting()
    {
        if (this.isDead) return;
        if (!this.isHurt) return;
        this.Hurt();
        this.StopHurt();
    }
    protected virtual void Hurt()
    {

    }
    protected virtual void StopHurt()
    {
        this.hurtTimeCounter += Time.deltaTime;
        if (this.hurtTimeCounter < this.hurtTime) return;
        this.hurtTimeCounter = 0;
        this.isHurt = false;
    }
}
