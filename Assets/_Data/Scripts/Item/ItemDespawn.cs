using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : DespawnByDistance
{
    public override void DespawnObj()
    {
        ItemDropSpawn.Instance.Despawn(transform.parent);
    }
}
