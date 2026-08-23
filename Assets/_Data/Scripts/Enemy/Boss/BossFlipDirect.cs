using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlipDirect : EnemyFlipDirect
{
    [SerializeField] protected float direct;
    protected override void Update()
    {
        
    }
    public void Flipping(Transform target)
    {
        this.direct = target.position.x - transform.position.x;
        this.Flip(this.direct);
    }
}
