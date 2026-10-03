using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowCtrl : DinoBehaviourScript
{
    [SerializeField] protected ArrowDespawn arrowDespawn;
    [SerializeField] Transform shooter;
    public ArrowDespawn ArrowDespawn => arrowDespawn;
    public Transform Shooter => shooter;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadArrowDespawn();
    }
    protected void LoadArrowDespawn()
    {
        if (this.arrowDespawn != null) return;
        this.arrowDespawn = GetComponentInChildren<ArrowDespawn>();
    }
    public void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
