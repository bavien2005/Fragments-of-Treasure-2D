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
        if (this.enemyCtrl.EnemyFollow.AlwaysFollowPlayer)
        {
            this.FlipWithPlayer();
            return;
        }
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
        if (!this.enemyCtrl.EnemyFollow.AlwaysFollowPlayer && !this.enemyCtrl.EnemyDetect.Detect) return;
        if (this.enemyCtrl.EnemyFollow.Target == null) return;
        float directPlayer = this.enemyCtrl.EnemyFollow.Target.position.x - transform.parent.position.x;
        this.Flip(directPlayer);
    }
    protected void Flip(float direct)
    {
        if (direct == 0) return;

        Vector3 scale = transform.parent.localScale;
        float scaleX = Mathf.Abs(scale.x);
        scale.x = direct > 0 ? scaleX : -scaleX;
        transform.parent.localScale = scale;
    }
}
