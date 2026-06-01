using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlipDirect : EnemyAbstract
{
    // [Header("Enemy Flip Direct")]
    protected virtual void Update()
    {
        this.Flipping();
    }

    protected void Flipping()
    {
        if (this.enemyCtrl.EnemyDamReceive.IsDead) return;
        this.FlipWithWayPoint();
        this.FlipWithPlayer();

    }
    protected void FlipWithWayPoint()
    {
        if (this.enemyCtrl.EnemyDetect.Detect) return;
        float directWayPoint = this.enemyCtrl.EnemyMovement.WayPoint.x - transform.parent.position.x;
        this.Flip(directWayPoint);
    }
    protected void FlipWithPlayer()
    {
        if (!this.enemyCtrl.EnemyDetect.Detect) return;
        float directPlayer = this.enemyCtrl.EnemyFollow.Target.position.x - transform.parent.position.x;
        this.Flip(directPlayer);
    }
    protected void Flip(float direct)
    {
        if (direct > 0 && transform.parent.localScale.x == -1) transform.parent.localScale = new Vector3(1, 1, 1);
        if (direct < 0 && transform.parent.localScale.x == 1) transform.parent.localScale = new Vector3(-1, 1, 1);
    }
}
