using UnityEngine;
using UnityEngine.UI;

public class SliderHp : BaseSlider
{
    [Header("Hp")]
    [SerializeField] protected float maxHp = 1;
    [SerializeField] protected float currentHp = 1;
    protected void FixedUpdate()
    {
        this.HpShowing();
    }
    protected void HpShowing()
    {
        float hpPercent = this.currentHp / this.maxHp;
        this.slider.value = hpPercent;
    }
    protected override void OnChanged(float newValue)
    {
        // Debug.Log("" + newValue);
    }
    public void SetMaxHp(float maxHp)
    {
        this.maxHp = maxHp;
    }
    public void SetCurrentHp(float currentHp)
    {
        this.currentHp = currentHp;
    }
}