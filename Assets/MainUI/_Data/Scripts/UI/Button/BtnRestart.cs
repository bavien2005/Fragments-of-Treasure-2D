using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnRestart : BaseButton
{
    [Header("Btn Restart")]
    [SerializeField] protected SceneName sceneName;
    [SerializeField] protected ArrowSO arrowSO;
    [SerializeField] protected HpPotionSO hpPotionSO;
    [SerializeField] protected InventorySO inventorySO;
    [SerializeField] protected PlayerHpSO playerHpSO;
    [SerializeField] protected PlayerPos playerPos;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadArrowSO();
        this.LoadHpPotionSO();
        this.LoadInventorySO();
        this.LoadPlayerHpSO();
        this.LoadPlayerPos();
    }
    protected void LoadArrowSO()
    {
        if (this.arrowSO != null) return;
        this.arrowSO = Resources.Load<ArrowSO>("GameData/ArrowSO");
        Debug.Log(transform.name + ": LOadArrowSO", gameObject);
    }
    protected void LoadHpPotionSO()
    {
        if (this.hpPotionSO != null) return;
        this.hpPotionSO = Resources.Load<HpPotionSO>("GameData/HpPotionSO");
        Debug.Log(transform.name + ": LoadHpPotionSO", gameObject);
    }
    protected void LoadInventorySO()
    {
        if (this.inventorySO != null) return;
        this.inventorySO = Resources.Load<InventorySO>("GameData/InventorySO");
        Debug.Log(transform.name + ": LoadInventorySO", gameObject);
    }
    protected void LoadPlayerHpSO()
    {
        if (this.playerHpSO != null) return;
        this.playerHpSO = Resources.Load<PlayerHpSO>("GameData/PlayerHpSO");
        Debug.Log(transform.name + ": LoadPlayerHpSO", gameObject);
    }
    protected void LoadPlayerPos()
    {
        if (this.playerPos != null) return;
        this.playerPos = Resources.Load<PlayerPos>("GameData/PlayerPos");
        Debug.Log(transform.name + ": LoadPlayerPos", gameObject);
    }
    protected override void OnClick()
    {
        this.ResetValues();
        this.BackFirstScene();
    }
    protected void BackFirstScene()
    {
        SceneManager.LoadScene(sceneName.ToString());
    }
    protected void ResetValues()
    {
        this.arrowSO.arrowCounts = 20;
        this.hpPotionSO.hpPotionCount = 3;
        this.playerHpSO.currentHp = 10;
        this.playerPos.intialValue = new Vector2(-16, 3);
    }
}
