using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpCountText : BaseText
{
    [Header("HpCount Text")]
    [SerializeField] protected HpPotionSO hpPotionSO;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHpPotionSO();
    }
    protected void Update()
    {
        this.ShowingArrowCount();
    }
    protected void LoadHpPotionSO()
    {
        if (this.hpPotionSO != null) return;
        this.hpPotionSO = Resources.Load<HpPotionSO>("GameData/HpPotionSO");
        Debug.Log(transform.name + ": LoadHpPotionSO", gameObject);
    }
    protected void ShowingArrowCount()
    {
        this.text.SetText(this.hpPotionSO.hpPotionCount.ToString());
    }
}