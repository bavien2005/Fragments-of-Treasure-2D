using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnByTime
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
    }
    protected void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl");
    }
    public override void DespawnObj()
    {
        if (EnemySpawn.Instance == null)
        {
            base.DespawnObj();
            return;
        }
        EnemySpawn.Instance.Despawn(transform.parent);
    }
    protected override bool CanDespawn()
    {
        if (!this.enemyCtrl.EnemyDamReceive.IsDead) return false;
        return base.CanDespawn();
    }
}
