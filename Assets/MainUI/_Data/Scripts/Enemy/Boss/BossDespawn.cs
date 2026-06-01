using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDespawn : DespawnByTime
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.delayTime = 3f;
    }
    public override void DespawnObj()
    {
        transform.parent.gameObject.SetActive(false);
    }
    protected override bool CanDespawn()
    {
        if (!BossCtrl.Instance.BossDamReceive.IsDead) return false;
        return base.CanDespawn();
    }
}
