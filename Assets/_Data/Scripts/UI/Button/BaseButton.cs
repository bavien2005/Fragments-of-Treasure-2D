using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : DinoBehaviourScript
{
    [Header("Base Button")]
    [SerializeField] protected Button button;
    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadButton();
    }
    protected void LoadButton()
    {
        if (this.button != null) return;
        this.button = GetComponent<Button>();
        Debug.Log(transform.name + ": LoadButton", gameObject);
    }
    protected void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }
    protected abstract void OnClick();
}
