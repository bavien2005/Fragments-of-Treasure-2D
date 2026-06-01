using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : DinoBehaviourScript
{
    protected void FixedUpdate()
    {
        this.Despawning();
    }
    protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObj();
    }
    public virtual void DespawnObj()
    {
        Destroy(transform.parent.gameObject);
    }
    protected abstract bool CanDespawn();
}
