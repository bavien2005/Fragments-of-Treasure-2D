using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoBehaviourScript : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponent();
    }
    protected virtual void Reset()
    {
        this.LoadComponent();
        this.ResetValue();
    }
    protected virtual void Start()
    {

    }
    protected virtual void OnEnable()
    {

    }
    protected virtual void LoadComponent()
    {

    }
    protected virtual void ResetValue()
    {

    }
}
