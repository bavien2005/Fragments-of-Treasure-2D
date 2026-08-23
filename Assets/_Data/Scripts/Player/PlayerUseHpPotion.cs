using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseHpPotion : PlayerAbstract
{
    [Header("PlayerUseHpPotion")]
    [SerializeField] protected HpPotionSO hpPotionSO;
    [SerializeField] protected bool canHeal = true;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHpPotionSO();
    }
    void Update()
    {
        this.Healing();
    }
    protected void LoadHpPotionSO()
    {
        if (this.hpPotionSO != null) return;
        this.hpPotionSO = Resources.Load<HpPotionSO>("GameData/HpPotionSO");
        Debug.Log(transform.name + ": LoadHpPotionSO", gameObject);
    }

    protected void Healing()
    {
        if (this.playerCtrl.PlayerDamReceive.Hp >= this.playerCtrl.PlayerDamReceive.HPMax) return;

        if (InputManager.Instance.GetInputHealing() && this.canHeal)
        {
            if (this.hpPotionSO.hpPotionCount <= 0) return;
            this.Heal();
            AudioManagerr.Instance.PlaySFX("Heal");
            this.canHeal = false;
        }

        if (!InputManager.Instance.GetInputHealing()) this.canHeal = true;
    }

    protected void Heal()
    {
        this.OnHealingFX();
        this.playerCtrl.PlayerDamReceive.Add(1);
        this.hpPotionSO.hpPotionCount--;
    }

    protected Transform OnHealingFX()
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        Transform healFX = FXSpawn.Instance.Spawn(FXSpawn.Instance.FXOne, pos, rot);
        return healFX;
    }
}
