using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOpenDoor : DinoBehaviourScript
{
    [SerializeField] protected BossCtrl bossCtrl;
    [SerializeField] Transform sceneTrans;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossCtrl();
        this.LoadSceneTrans();
    }
    protected void LoadBossCtrl()
    {
        if (this.bossCtrl != null) return;
        this.bossCtrl = GetComponentInParent<BossCtrl>();
    }
    protected void LoadSceneTrans()
    {
        if (this.sceneTrans != null) return;
        this.sceneTrans = GameObject.Find("SceneTransition_1").transform;
    }
    protected void Update()
    {
        if (this.bossCtrl.BossDamReceive.IsDead) this.sceneTrans.gameObject.SetActive(true);
    }
}
