using UnityEngine;
using UnityEngine.UI;

public class EnemyDamReceiver : DamageReceiver
{
    [SerializeField] private Slider slider;

    private void Start()
    {
        slider.maxValue = base.HPMax;
        slider.value = base.Hp;
    }
    public override void Deduct(int damage)
    {

        base.Deduct(damage);
        slider.value = base.Hp;
        Debug.Log(gameObject.name + " bị trừ máu: " + damage);
    }

    protected override void OnDead()
    {
        Debug.Log(gameObject.name + " chết");
        Destroy(gameObject);
    }
}
