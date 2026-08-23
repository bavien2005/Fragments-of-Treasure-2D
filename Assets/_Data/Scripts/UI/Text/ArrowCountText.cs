using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArrowCountText : BaseText
{
    [Header("ArrowCount Text")]
    [SerializeField] protected ArrowSO arrowSO;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadArrowSO();
    }
    protected void Update()
    {
        this.ShowingArrowCount();
    }
    protected void LoadArrowSO()
    {
        if (this.arrowSO != null) return;
        this.arrowSO = Resources.Load<ArrowSO>("GameData/ArrowSO");
        Debug.Log(transform.name + ": LoadArrowSO", gameObject);
    }
    protected void ShowingArrowCount()
    {
        this.text.SetText(ArrowPlayerSpawn.Instance.SpawnCount.ToString());
    }
}