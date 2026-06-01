using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDespawn : DespawnByDistance
{
    public override void DespawnObj()
    {
        if (ArrowPlayerSpawn.Instance != null)
            ArrowPlayerSpawn.Instance.Despawn(transform.parent);
        else
            ArrowEnemySpawn.Instance.Despawn(transform.parent);
    }
}
