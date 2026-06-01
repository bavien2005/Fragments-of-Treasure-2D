using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamSender : DamageSender
{
    [Header("Arrow Dam Sender")]
    [SerializeField] protected ArrowCtrl arrowCtrl;
    public ArrowCtrl ArrowCtrl => arrowCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadArrowCtrl();
    }
    protected void LoadArrowCtrl()
    {
        if (this.arrowCtrl != null) return;
        this.arrowCtrl = GetComponentInParent<ArrowCtrl>();
        Debug.Log(transform.name + ": LoadArrowCtrl", gameObject);
    }
    protected override void SendToTransform(Transform collider)
    {
        base.SendToTransform(collider);
        if (!this.canSendDamage) return;
        this.arrowCtrl.ArrowDespawn.DespawnObj();
        this.canSendDamage = false;
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.parent == this.arrowCtrl.Shooter) return;
        SendToTransform(collider.transform);
    }
}
