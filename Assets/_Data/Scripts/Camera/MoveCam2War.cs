using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam2War : DinoBehaviourScript
{
    [SerializeField] protected Camera mainCam;
    [SerializeField] protected FollowPlayer followPlayer;
    [SerializeField] protected FollowTarget followTarget;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
        this.LoadFollowPlayer();
        this.LoadFollowTarget();
    }
    protected void Update()
    {
        if (!BossCtrl.Instance.BossMovement.CanMove()) return;
        this.mainCam.orthographicSize = 10;
        this.followPlayer.enabled = false;
        this.followTarget.enabled = true;

    }
    protected void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = FindAnyObjectByType<Camera>();
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }
    protected void LoadFollowPlayer()
    {
        if (this.followPlayer != null) return;
        this.followPlayer = GameObject.Find("HoldCamera").transform.GetComponent<FollowPlayer>();
        Debug.Log(transform.name + ": LoadFollowPlayer", gameObject);
    }

    protected void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = GameObject.Find("HoldCamera").transform.GetComponent<FollowTarget>();
        Debug.Log(transform.name + ": LoadFollowTarget", gameObject);
    }


}
