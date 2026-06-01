using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : DinoBehaviourScript
{
    [SerializeField] protected float speed = 100;
    [SerializeField] protected Transform target;

    protected void FixedUpdate()
    {
        this.Following();
    }
    protected void Following()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp
        (transform.position, this.target.position, this.speed * Time.fixedDeltaTime);
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
