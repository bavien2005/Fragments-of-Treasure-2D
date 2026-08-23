using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseToggle : DinoBehaviourScript
{
    [Header("Base Toggle")]
    [SerializeField] protected Transform sceneTrans;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSceneTrans();
    }

    protected void LoadSceneTrans()
    {
        if (this.sceneTrans != null) return;
        this.sceneTrans = GameObject.Find("SceneTransition").transform;
        Debug.Log(transform.name + ": LoadSceneTrans", gameObject);
    }
}
