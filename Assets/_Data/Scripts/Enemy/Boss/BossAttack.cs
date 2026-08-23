using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : DinoBehaviourScript
{
    [SerializeField] protected BossAttackCtrl bossAttackCtrl;
    protected override void Start()
    {
        base.Start();
        AudioManagerr.Instance.OpenMusic();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossAttackCtrl();
    }

    protected void LoadBossAttackCtrl()
    {
        if (this.bossAttackCtrl != null) return;
        this.bossAttackCtrl = GetComponent<BossAttackCtrl>();
        Debug.Log(transform.name + ": LoadBossAttackCtrl", gameObject);
    }

    protected void FixedUpdate()
    {
        if (PlayerCtrl.Instance.PlayerDamReceive.IsDead) return;
        if (this.bossAttackCtrl.BossCtrl.BossDamReceive.IsDead) return;
        if (this.bossAttackCtrl.BossCtrl.BossDamReceive.Hp > 30)
        {
            this.bossAttackCtrl.BossAttack1.Attacking1();
            this.bossAttackCtrl.BossAttack2.Attacking2();
        }
        this.bossAttackCtrl.BossAttack3.Attacking3();
    }
}
