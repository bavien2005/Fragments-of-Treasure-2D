using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarBoss : HpBar
{
    protected override void HpShowing()
    {
        this.hp = BossCtrl.Instance.BossDamReceive.Hp;
        this.hpMax = BossCtrl.Instance.BossDamReceive.HPMax;

        base.HpShowing();
    }
}
