using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keeps Treasure Resonance stacks on an enemy and detonates at three stacks.
/// </summary>
public class TreasureResonanceMark : MonoBehaviour
{
    protected const int requiredMarks = 3;
    protected EnemyDamReceive damageReceiver;
    protected EnemyCtrl enemyCtrl;
    protected readonly List<SpriteRenderer> markOrbs = new List<SpriteRenderer>();
    protected int marks;
    protected float lifetime = 4f;
    protected float lastMarkTime;

    public void AddMark(EnemyDamReceive receiver, int detonationDamage, float slowMultiplier, float slowDuration)
    {
        if (receiver == null || receiver.IsDead) return;
        this.damageReceiver = receiver;
        if (this.enemyCtrl == null) this.enemyCtrl = GetComponent<EnemyCtrl>();

        this.lastMarkTime = Time.time;
        if (this.enemyCtrl != null && this.enemyCtrl.EnemyMovement != null)
            this.enemyCtrl.EnemyMovement.ApplyTreasureSlow(slowMultiplier, slowDuration);

        this.marks++;
        this.RefreshOrbs();

        if (this.marks < requiredMarks) return;
        receiver.Deduct(detonationDamage);
        TreasureResonanceVfx.SpawnDetonation(receiver.transform.position);
        BossResonanceImpact bossImpact = this.enemyCtrl != null ? this.enemyCtrl.GetComponent<BossResonanceImpact>() : null;
        if (bossImpact != null) bossImpact.PlayDetonation();
        else if (AudioManagerr.Instance != null) AudioManagerr.Instance.PlaySFX("SwordBlood", 0.75f);
        this.ClearOrbs();
        Destroy(this);
    }

    protected void Update()
    {
        if (this.damageReceiver == null || this.damageReceiver.IsDead || Time.time - this.lastMarkTime > this.lifetime)
        {
            this.ClearOrbs();
            Destroy(this);
        }
    }

    protected void RefreshOrbs()
    {
        while (this.markOrbs.Count < this.marks)
        {
            GameObject orb = new GameObject("TreasureMarkOrb");
            orb.transform.SetParent(transform, false);
            orb.transform.localScale = Vector3.one * 0.18f;
            SpriteRenderer renderer = orb.AddComponent<SpriteRenderer>();
            renderer.sprite = TreasureResonanceVfx.GlowSprite;
            renderer.color = new Color(1f, 0.69f, 0.18f, 1f);
            renderer.sortingOrder = 70;
            this.markOrbs.Add(renderer);
        }
    }

    protected void LateUpdate()
    {
        for (int i = 0; i < this.markOrbs.Count; i++)
        {
            if (this.markOrbs[i] == null) continue;
            float angle = Time.time * 3.5f + Mathf.PI * 2f * i / this.markOrbs.Count;
            this.markOrbs[i].transform.localPosition = new Vector3(Mathf.Cos(angle), 0.42f + Mathf.Sin(angle) * 0.23f, 0f);
            this.markOrbs[i].transform.localScale = Vector3.one * (0.16f + Mathf.Sin(Time.time * 7f + i) * 0.025f);
        }
    }

    protected void ClearOrbs()
    {
        foreach (SpriteRenderer orb in this.markOrbs)
            if (orb != null) Destroy(orb.gameObject);
        this.markOrbs.Clear();
    }

    protected void OnDestroy()
    {
        this.ClearOrbs();
    }
}
