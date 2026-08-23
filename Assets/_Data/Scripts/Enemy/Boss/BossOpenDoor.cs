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
        Debug.Log(transform.name + ": LoadBossCtrl", gameObject);
    }
    protected void LoadSceneTrans()
    {
        if (this.sceneTrans != null) return;
        this.sceneTrans = GameObject.Find("SceneTransition_1").transform;
        Debug.Log(transform.name + ": LoadSceneTrans", gameObject);
    }
    protected void Update()
    {
        if (this.bossCtrl.BossDamReceive.IsDead) this.sceneTrans.gameObject.SetActive(true);
    }
}
