using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamReceive : EnemyDamReceive
{
    protected override void SetPosDead()
    {

    }

    protected override void OnDead()
    {
        base.OnDead();
        AudioManagerr.Instance.StopMusic();
    }
}
