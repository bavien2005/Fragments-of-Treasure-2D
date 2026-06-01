using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DespawnByTime : Despawn
{
    [Header("Despawn By Time")]
    [SerializeField] protected float delayTime = 5f;
    [SerializeField] protected float timer = 0f;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetTime();
    }
    protected virtual void ResetTime()
    {
        this.timer = 0f;
    }
    protected override bool CanDespawn()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delayTime) return false;
        return true;
    }
}
