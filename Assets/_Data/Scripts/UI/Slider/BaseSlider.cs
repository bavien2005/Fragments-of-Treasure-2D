using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : DinoBehaviourScript
{
    [Header("Base Slider")]
    [SerializeField] protected Slider slider;
    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSlider();
    }
    protected void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.Log(transform.name + ": LoadSlider", gameObject);
    }
    protected void AddOnClickEvent()
    {
        this.slider.onValueChanged.AddListener(this.OnChanged);
    }
    protected abstract void OnChanged(float newValue);
}
