using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseText : DinoBehaviourScript
{
    [Header("Base Text")]
    [SerializeField] protected TextMeshProUGUI text;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadText();
    }
    protected void LoadText()
    {
        if (this.text != null) return;
        this.text = GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadText", gameObject);
    }
}
