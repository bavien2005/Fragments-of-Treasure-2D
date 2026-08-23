using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHpBarCtrl : DinoBehaviourScript
{
    [SerializeField] protected Canvas canvasBoss;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCanvasBoss();
    }
    protected override void Start()
    {
        base.Start();
        this.canvasBoss.gameObject.SetActive(false);
    }
    protected void LoadCanvasBoss()
    {
        if (this.canvasBoss != null) return;
        this.canvasBoss = GameObject.Find("HpBarBoss").GetComponent<Canvas>();
        Debug.Log(transform.name + ": LoadCanvasBoss", gameObject);
    }
    protected void Update()
    {
        this.ControlHpBar();
    }

    protected void ControlHpBar()
    {
        if (BossCtrl.Instance.BossDamReceive.IsDeaded())
        {
            this.canvasBoss.gameObject.SetActive(false);
            return;
        }

        if (!BossCtrl.Instance.BossMovement.CanMove()) return;
        this.canvasBoss.gameObject.SetActive(true);
    }
}
