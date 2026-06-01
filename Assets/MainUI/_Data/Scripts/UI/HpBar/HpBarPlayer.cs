using UnityEngine;
using UnityEngine.UI;

public class HpBarPlayer : HpBar
{
    // [Header("Hp Bar Player")]
    protected override void HpShowing()
    {
        this.hp = PlayerCtrl.Instance.PlayerDamReceive.Hp;
        this.hpMax = PlayerCtrl.Instance.PlayerDamReceive.HPMax;

        base.HpShowing();
    }

}