using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DespawnByDistance : Despawn
{
    [Header("Despawn By Distance")]
    [SerializeField] protected Camera mainCam;
    [SerializeField] protected float distance;
    [SerializeField] protected float distanceMax = 20f;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
    }
    protected void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = FindAnyObjectByType<Camera>();
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(this.mainCam.transform.position, transform.position);
        if (this.distance >= this.distanceMax) return true;
        return false;
    }
}
